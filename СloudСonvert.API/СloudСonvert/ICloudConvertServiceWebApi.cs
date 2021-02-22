using System.Threading.Tasks;
using Refit;
using СloudСonvert.API.СloudСonvert.Models.Enums;
using СloudСonvert.API.СloudСonvert.Models.JobModels;
using СloudСonvert.API.СloudСonvert.Models.TaskModels;

namespace СloudСonvert.API.СloudСonvert
{
  public interface ICloudConvertServiceWebApi
  {
    #region Jobs

    /// <summary>
    /// Lists jobs
    /// List all jobs. Requires the task.read scope.
    /// </summary>
    /// <param name="api_key"></param>
    /// <param name="status"></param>
    /// <param name="tag"></param>
    /// <param name="include"></param>
    /// <param name="perPage"></param>
    /// <param name="page"></param>
    /// <returns>
    /// The list of jobs. You can find details about the job model response in the documentation about the show jobs endpoint.
    /// </returns>
    [Get("/jobs?filter[status]={status}&filter[tag]={tag}&include={include}&per_page={perPage}&page={page}")]
    Task<JobsResponse> GetAllJobs([Header("Authorization")] string api_key, JobCCStatus? status = null, string tag = null, string include = null, int? perPage = null, int? page = null);

    /// <summary>
    /// Create job
    /// Create a job with one ore more tasks. Requires the task.write scope.
    /// </summary>
    /// <param name="api_key"></param>
    /// <param name="request"></param>
    /// <returns>
    /// The created job. You can find details about the job model response in the documentation about the show jobs endpoint.
    /// </returns>
    [Post("/jobs")]
    Task CreateJob([Header("Authorization")] string api_key, [Body] JobCreateRequest request);

    /// <summary>
    /// Show a job
    /// Show a job. Requires the task.read scope.
    /// </summary>
    /// <param name="api_key"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [Get("/jobs/{id}")]
    Task<JobResponse> GetJob([Header("Authorization")] string api_key, string id);

    /// <summary>
    /// Wait for a job
    /// Wait until the job status is finished or error. This makes the request block until the job has been completed. Requires the task.read scope.
    /// 
    /// We do not recommend using this for long running jobs (e.g. video encodings). 
    /// Your system might automatically time out requests if there is not data transferred for a longer time.
    /// In general, please avoid to block your application until a CloudConvert job completes.
    /// There might be cases in which we need to queue your job which results in longer processing times than usual.
    /// Using an asynchronous approach with webhooks is beneficial in such cases.
    /// </summary>
    /// <param name="api_key"></param>
    /// <param name="id"></param>
    /// <returns>
    /// The finished or failed job, including tasks. You can find details about the job model response in the documentation about the show job endpoint.
    /// </returns>
    [Get("/jobs/{id}/wait")]
    Task<JobResponse> WaitJob([Header("Authorization")] string api_key, string id);

    /// <summary>
    /// Delete a job
    /// Delete a job, including all tasks and data. Requires the task.write scope.
    /// Jobs are deleted automatically 24 hours after they have ended.
    /// </summary>
    /// <param name="api_key"></param>
    /// <param name="id"></param>
    /// <returns>
    /// An empty response with HTTP Code 204.
    /// </returns>
    [Delete("/jobs/{id}")]
    Task DeleteJob([Header("Authorization")] string api_key, string id);

    #endregion

    #region Tasks

    /// <summary>
    /// Lists tasks
    /// List all tasks with their status, payload and result. Requires the task.read scope.
    /// </summary>
    /// <param name="api_key"></param>
    /// <param name="status"></param>
    /// <param name="tag"></param>
    /// <param name="include"></param>
    /// <param name="perPage"></param>
    /// <param name="page"></param>
    /// <returns></returns>
    [Get("/tasks?filter[job_id]={jobId}&filter[status]={status}&filter[operation]={operation}&include={include}&per_page={perPage}&page={page}")]
    Task<TasksResponse> GetAllTasks([Header("Authorization")] string api_key, string jobId = null, TaskCCStatus? status = null, string operation = null, string[] include = null, int? perPage = null, int? page = null);

    /// <summary>
    /// Show a job
    /// Show a task. Requires the task.read scope.
    /// </summary>
    /// <param name="api_key"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [Get("/tasks/{id}?include={include}")]
    Task<TaskResponse> GetTask([Header("Authorization")] string api_key, string id, string[] include = null);

    /// <summary>
    /// Wait for a job
    /// Wait until the task status is finished or error. This makes the request block until the task has been completed. Requires the task.read scope.
    /// 
    /// We do not recommend using this for long running jobs (e.g. video encodings). 
    /// Your system might automatically time out requests if there is not data transferred for a longer time.
    /// In general, please avoid to block your application until a CloudConvert job completes.
    /// There might be cases in which we need to queue your task which results in longer processing times than usual.
    /// Using an asynchronous approach with webhooks is beneficial in such cases.
    /// </summary>
    /// <param name="api_key"></param>
    /// <param name="id"></param>
    /// <returns>
    /// The finished or failed task. You can find details about the task model response in the documentation about the show tasks endpoint.
    /// </returns>
    [Get("/tasks/{id}/wait")]
    Task<TaskResponse> WaitTask([Header("Authorization")] string api_key, string id);

    /// <summary>
    /// Delete a job
    /// Delete a task, including all data. Requires the task.write scope.
    /// Tasks are deleted automatically 24 hours after they have ended.
    /// </summary>
    /// <param name="api_key"></param>
    /// <param name="id"></param>
    /// <returns>
    /// An empty response with HTTP Code 204.
    /// </returns>
    [Delete("/tasks/{id}")]
    Task DeleteTask([Header("Authorization")] string api_key, string id);

    #endregion
  }
}
