using System.Threading.Tasks;
using СloudСonvert.API.Models.JobModels;
using СloudСonvert.API.Models.TaskModels;
using СloudСonvert.API.Models.TaskOperations;

namespace СloudСonvert.API
{
  public class CloudConvertAPI
  {
    readonly string _apiUrl;
    readonly ICloudConvertServiceWebApi _api;
    readonly string _api_key = "Bearer ";

    public CloudConvertAPI(string api_key)
    {
      _api_key += api_key;
      _api = CloudConvertServiceWebApiFactory.CreateWebApi(_apiUrl);
    }

    public CloudConvertAPI(string url, string api_key)
    {
      _apiUrl = url;
      _api_key += api_key;
      _api = CloudConvertServiceWebApiFactory.CreateWebApi(_apiUrl);
    }

    #region Jobs

    /// <summary>
    /// List all jobs. Requires the task.read scope.
    /// </summary>
    /// <param name="jobFilter"></param>
    /// <returns>
    /// The list of jobs. You can find details about the job model response in the documentation about the show jobs endpoint.
    /// </returns>
    public Task<JobsResponse> GetAllJobsAsync(JobFilter jobFilter) => _api.GetAllJobs(_api_key, jobFilter.Status, jobFilter.Tag, jobFilter.Include, jobFilter.PerPage, jobFilter.Page);

    /// <summary>
    /// Create a job with one ore more tasks. Requires the task.write scope.
    /// </summary>
    /// <param name="request"></param>
    /// <returns>
    /// The created job. You can find details about the job model response in the documentation about the show jobs endpoint.
    /// </returns>
    public Task<JobResponse> CreateJobAsync(JobCreateRequest request) => _api.CreateJob(_api_key, request);

    /// <summary>
    /// Show a job. Requires the task.read scope.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<JobResponse> GetJobAsync(string id) => _api.GetJob(_api_key, id);

    /// <summary>
    /// Wait until the job status is finished or error. This makes the request block until the job has been completed. Requires the task.read scope.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// The finished or failed job, including tasks. You can find details about the job model response in the documentation about the show job endpoint.
    /// </returns>
    public Task<JobResponse> WaitJobAsync(string id) => _api.WaitJob(_api_key, id);

    /// <summary>
    /// Delete a job, including all tasks and data. Requires the task.write scope.
    /// Jobs are deleted automatically 24 hours after they have ended.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// An empty response with HTTP Code 204.
    /// </returns>
    public Task DeleteJobAsync(string id) => _api.DeleteJob(_api_key, id);

    #endregion

    #region Tasks

    /// <summary>
    /// List all tasks with their status, payload and result. Requires the task.read scope.
    /// </summary>
    /// <param name="jobFilter"></param>
    /// <returns>
    /// The list of tasks. You can find details about the task model response in the documentation about the show tasks endpoint.
    /// </returns>
    public Task<TasksResponse> GetAllTasksAsync(TaskFilter jobFilter) => _api.GetAllTasks(_api_key, jobFilter.JobId, jobFilter.Status, jobFilter.Operation, jobFilter.Include, jobFilter.PerPage, jobFilter.Page);

    /// <summary>
    /// Create task.
    /// </summary>
    /// <param name="request"></param>
    /// <returns>
    /// The created task. You can find details about the task model response in the documentation about the show tasks endpoint.
    /// </returns>
    public Task<TaskResponse> CreateTaskAsync(string operation, TaskConvertData request) => _api.CreateTask(_api_key, operation, request);

    /// <summary>
    /// Show a task. Requires the task.read scope.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="include"></param>
    /// <returns></returns>
    public Task<TaskResponse> GetTaskAsync(string id, string[] include = null) => _api.GetTask(_api_key, id, include);

    /// <summary>
    /// Wait until the task status is finished or error. This makes the request block until the task has been completed. Requires the task.read scope.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// The finished or failed task. You can find details about the task model response in the documentation about the show tasks endpoint.
    /// </returns>
    public Task<TaskResponse> WaitTaskAsync(string id) => _api.WaitTask(_api_key, id);

    /// <summary>
    /// Delete a task, including all data. Requires the task.write scope.
    /// Tasks are deleted automatically 24 hours after they have ended.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// An empty response with HTTP Code 204.
    /// </returns>
    public Task DeleteTaskAsync(string id) => _api.DeleteTask(_api_key, id);


    //public Task<TaskResponse> UploadAsync(StreamPart file) => _api.Upload(_api_key, file);
    #endregion
  }
}
