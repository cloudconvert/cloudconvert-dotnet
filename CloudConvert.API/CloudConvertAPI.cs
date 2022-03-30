using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CloudConvert.API.Models.JobModels;
using CloudConvert.API.Models.TaskModels;
using CloudConvert.API.Models;

namespace CloudConvert.API
{
  public interface ICloudConvertAPI
  {
    #region Jobs
    Task<ListResponse<JobResponse>> GetAllJobsAsync(JobListFilter jobFilter);
    Task<Response<JobResponse>> CreateJobAsync(JobCreateRequest request);
    Task<Response<JobResponse>> GetJobAsync(string id);
    Task<Response<JobResponse>> WaitJobAsync(string id);
    Task DeleteJobAsync(string id);
    #endregion

    #region Tasks
    Task<ListResponse<TaskResponse>> GetAllTasksAsync(TaskListFilter jobFilter);
    Task<Response<TaskResponse>> CreateTaskAsync<T>(string operation, T request);
    Task<Response<TaskResponse>> GetTaskAsync(string id, string[] include = null);
    Task<Response<TaskResponse>> WaitTaskAsync(string id);
    Task DeleteTaskAsync(string id);
    #endregion

    Task<string> UploadAsync(string url, byte[] file, string fileName, object parameters);
    bool ValidateWebhookSignatures(string payloadString, string signature, string signingSecret);
    string CreateSignedUrl(string baseUrl, string signingSecret, JobCreateRequest job, string cacheKey = null);
  }

  public class CloudConvertAPI : ICloudConvertAPI
  {
    readonly string _apiUrl;
    readonly string _apiSyncUrl;

    readonly RestHelper _restHelper;
    readonly string _api_key = "Bearer ";
    const string sandboxUrlApi = "https://api.sandbox.cloudconvert.com/v2";
    const string publicUrlApi = "https://api.cloudconvert.com/v2";
    const string sandboxUrlSyncApi = "https://sync.api.sandbox.cloudconvert.com/v2";
    const string publicUrlSyncApi = "https://sync.api.cloudconvert.com/v2";
    static readonly char[] base64Padding = { '=' };


    public CloudConvertAPI(string api_key, bool isSandbox = false)
    {
      _apiUrl = isSandbox ? sandboxUrlApi : publicUrlApi;
      _apiSyncUrl = isSandbox ? sandboxUrlSyncApi : publicUrlSyncApi;
      _api_key += api_key;
      _restHelper = new RestHelper();
    }

    public CloudConvertAPI(string url, string api_key)
    {
      _apiUrl = url;
      _api_key += api_key;
      _restHelper = new RestHelper();
    }

    private HttpRequestMessage GetRequest(string endpoint, HttpMethod method, object model = null)
    {
      var request = new HttpRequestMessage { RequestUri = new Uri(endpoint), Method = method };
      
      if (model != null)
      {
        var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
        request.Content = content;
      }
      
      request.Headers.Add("Authorization", _api_key);
      request.Headers.Add("User-Agent", "cloudconvert-dotnet/v"  +  System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " (https://github.com/cloudconvert/cloudconvert-dotnet)");
     
      return request;
    }

    private HttpRequestMessage GetMultipartFormDataRequest(string endpoint, HttpMethod method, byte[] file, string fileName, Dictionary<string, string> parameters = null)
    {
      var content = new MultipartFormDataContent();
      var request = new HttpRequestMessage { RequestUri = new Uri(endpoint), Method = method, };

      if (parameters != null)
      {
        foreach (var param in parameters)
        {
          content.Add(new StringContent(param.Value), param.Key);
        }
      }

      content.Add(new ByteArrayContent(file), "file", fileName);

      request.Content = content;

      return request;
    }

    #region Jobs

    /// <summary>
    /// List all jobs. Requires the task.read scope.
    /// </summary>
    /// <param name="jobFilter"></param>
    /// <returns>
    /// The list of jobs. You can find details about the job model response in the documentation about the show jobs endpoint.
    /// </returns>
    public Task<ListResponse<JobResponse>> GetAllJobsAsync(JobListFilter jobFilter) => _restHelper.RequestAsync<ListResponse<JobResponse>>(GetRequest($"{_apiUrl}/jobs?filter[status]={jobFilter.Status}&filter[tag]={jobFilter.Tag}&include={jobFilter.Include}&per_page={jobFilter.PerPage}&page={jobFilter.Page}", HttpMethod.Get));

    /// <summary>
    /// Create a job with one ore more tasks. Requires the task.write scope.
    /// </summary>
    /// <param name="model"></param>
    /// <returns>
    /// The created job. You can find details about the job model response in the documentation about the show jobs endpoint.
    /// </returns>
    public Task<Response<JobResponse>> CreateJobAsync(JobCreateRequest model) => _restHelper.RequestAsync<Response<JobResponse>>(GetRequest($"{_apiUrl}/jobs", HttpMethod.Post, model));

    /// <summary>
    /// Show a job. Requires the task.read scope.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Response<JobResponse>> GetJobAsync(string id) => _restHelper.RequestAsync<Response<JobResponse>>(GetRequest($"{_apiUrl}/jobs/{id}", HttpMethod.Get));

    /// <summary>
    /// Wait until the job status is finished or error. This makes the request block until the job has been completed. Requires the task.read scope.
    /// 
    /// We do not recommend using this for long running jobs (e.g. video encodings). 
    /// Your system might automatically time out requests if there is not data transferred for a longer time.
    /// In general, please avoid to block your application until a CloudConvert job completes.
    /// There might be cases in which we need to queue your job which results in longer processing times than usual.
    /// Using an asynchronous approach with webhooks is beneficial in such cases.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// The finished or failed job, including tasks. You can find details about the job model response in the documentation about the show job endpoint.
    /// </returns>
    public Task<Response<JobResponse>> WaitJobAsync(string id) => _restHelper.RequestAsync<Response<JobResponse>>(GetRequest($"{_apiSyncUrl}/jobs/{id}", HttpMethod.Get));

    /// <summary>
    /// Delete a job, including all tasks and data. Requires the task.write scope.
    /// Jobs are deleted automatically 24 hours after they have ended.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// An empty response with HTTP Code 204.
    /// </returns>
    public Task DeleteJobAsync(string id) => _restHelper.RequestAsync<object>(GetRequest($"{_apiUrl}/jobs/{id}", HttpMethod.Delete));

    #endregion

    #region Tasks

    /// <summary>
    /// List all tasks with their status, payload and result. Requires the task.read scope.
    /// </summary>
    /// <param name="taskFilter"></param>
    /// <returns>
    /// The list of tasks. You can find details about the task model response in the documentation about the show tasks endpoint.
    /// </returns>
    public Task<ListResponse<TaskResponse>> GetAllTasksAsync(TaskListFilter taskFilter) => _restHelper.RequestAsync<ListResponse<TaskResponse>>(GetRequest($"{_apiUrl}/tasks?filter[job_id]={taskFilter.JobId}&filter[status]={taskFilter.Status}&filter[operation]={taskFilter.Operation}&include={taskFilter.Include}&per_page={taskFilter.PerPage}&page={taskFilter.Page}", HttpMethod.Get));

    /// <summary>
    /// Create task.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="model"></param>
    /// <returns>
    /// The created task. You can find details about the task model response in the documentation about the show tasks endpoint.
    /// </returns>
    public Task<Response<TaskResponse>> CreateTaskAsync<T>(string operation, T model) => _restHelper.RequestAsync<Response<TaskResponse>>(GetRequest($"{_apiUrl}/{operation}", HttpMethod.Post, model));

    /// <summary>
    /// Show a task. Requires the task.read scope.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="include"></param>
    /// <returns></returns>
    public Task<Response<TaskResponse>> GetTaskAsync(string id, string[] include = null) => _restHelper.RequestAsync<Response<TaskResponse>>(GetRequest($"{_apiUrl}/tasks/{id}?include={include}", HttpMethod.Get));

    /// <summary>
    /// Wait until the task status is finished or error. This makes the request block until the task has been completed. Requires the task.read scope.
    /// 
    /// We do not recommend using this for long running jobs (e.g. video encodings). 
    /// Your system might automatically time out requests if there is not data transferred for a longer time.
    /// In general, please avoid to block your application until a CloudConvert job completes.
    /// There might be cases in which we need to queue your task which results in longer processing times than usual.
    /// Using an asynchronous approach with webhooks is beneficial in such cases.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// The finished or failed task. You can find details about the task model response in the documentation about the show tasks endpoint.
    /// </returns>
    public Task<Response<TaskResponse>> WaitTaskAsync(string id) => _restHelper.RequestAsync<Response<TaskResponse>>(GetRequest($"{_apiSyncUrl}/tasks/{id}", HttpMethod.Get));

    /// <summary>
    /// Delete a task, including all data. Requires the task.write scope.
    /// Tasks are deleted automatically 24 hours after they have ended.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// An empty response with HTTP Code 204.
    /// </returns>
    public Task DeleteTaskAsync(string id) => _restHelper.RequestAsync<object>(GetRequest($"{_apiUrl}/tasks/{id}", HttpMethod.Delete));

    #endregion

    public Task<string> UploadAsync(string url, byte[] file, string fileName, object parameters) => _restHelper.RequestAsync(GetMultipartFormDataRequest($"{url}", HttpMethod.Post, file, fileName, GetParameters(parameters)));

    public string CreateSignedUrl(string baseUrl, string signingSecret, JobCreateRequest job, string cacheKey = null)
    {
      string url = baseUrl;
      string jobJson = JsonConvert.SerializeObject(job);
      string base64Job = System.Convert.ToBase64String(Encoding.ASCII.GetBytes(jobJson)).TrimEnd(base64Padding).Replace('+', '-').Replace('/', '_');
      
      url += "?job="  + base64Job;

      if(cacheKey != null) {
        url += "&cache_key=" + cacheKey;
      }

      string signature = HashHMAC(signingSecret, url);

      url += "&s=" + signature;

      return url;
    }

    public bool ValidateWebhookSignatures(string payloadString, string signature, string signingSecret)
    {
      string hashHMAC = HashHMAC(signingSecret, payloadString);

      return hashHMAC == signature;
    }

    private string HashHMAC(string key, string message)
    {
      byte[] hash = new HMACSHA256(Encoding.UTF8.GetBytes(key)).ComputeHash(new UTF8Encoding().GetBytes(message));
      return BitConverter.ToString(hash).Replace("-", "").ToLower();
    }

    private Dictionary<string, string> GetParameters(object parameters)
    {
      var attributes = ((JToken)parameters).ToList();
      Dictionary<string, string> dictionaryParameters = new Dictionary<string, string>();
      foreach (JToken attribute in attributes)
      {
        JProperty jProperty = attribute.ToObject<JProperty>();
        dictionaryParameters.Add(jProperty.Name, jProperty.Value.ToString());
      }

      return dictionaryParameters;
    }
  }
}
