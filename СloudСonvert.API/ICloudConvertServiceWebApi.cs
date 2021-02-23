using System.Threading.Tasks;
using Refit;
using СloudСonvert.API.Models.Enums;
using СloudСonvert.API.Models.JobModels;
using СloudСonvert.API.Models.TaskModels;
using СloudСonvert.API.Models.TaskOperations;

namespace СloudСonvert.API
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
    Task<JobResponse> CreateJob([Header("Authorization")] string api_key, [Body(BodySerializationMethod.Serialized)] JobCreateRequest request);

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
    /// Create сonvert task
    /// Create a task to convert one input file from input_format to output_format. Requires the task.write scope.
    /// </summary>
    /// <param name="api_key"></param>
    /// <param name="request"></param>
    /// <returns>
    /// The created task. You can find details about the task model response in the documentation about the show tasks endpoint.
    /// </returns>
    [Post("/convert")]
    Task<TaskResponse> CreateConvertTask([Header("Authorization")] string api_key, [Body(BodySerializationMethod.Serialized)] TaskConvertData request);

    /// <summary>
    /// Create optimize task
    /// Create a task to optimize and compress a file. Currently supported formats are PDF, PNG and JPG.
    /// </summary>
    /// <param name="api_key"></param>
    /// <param name="request"></param>
    /// <returns>
    /// The created task. You can find details about the task model response in the documentation about the show tasks endpoint.
    /// </returns>
    [Post("/optimize")]
    Task<TaskResponse> CreateOptimizeTask([Header("Authorization")] string api_key, [Body(BodySerializationMethod.Serialized)] TaskOptimizeData request);

    /// <summary>
    /// Create capture website task
    /// Create a task to convert a website to PDF or to capture a screenshot of a website (png, jpg).
    /// </summary>
    /// <param name="api_key"></param>
    /// <param name="request"></param>
    /// <returns>
    /// The created task. You can find details about the task model response in the documentation about the show tasks endpoint.
    /// </returns>
    [Post("/capture-website")]
    Task<TaskResponse> CreateCaptureWebsiteTask([Header("Authorization")] string api_key, [Body(BodySerializationMethod.Serialized)] TaskCaptureData request);

    /// <summary>
    /// Create thumbnail task
    /// Create a task to create a PNG or JPG thumbnail of one input file. Requires the task.write scope.
    /// </summary>
    /// <param name="api_key"></param>
    /// <param name="request"></param>
    /// <returns>
    /// The created task. You can find details about the task model response in the documentation about the show tasks endpoint.
    /// </returns>
    [Post("/thumbnail")]
    Task<TaskResponse> CreateThumbnailTask([Header("Authorization")] string api_key, [Body(BodySerializationMethod.Serialized)] TaskThumbnailData request);

    /// <summary>
    /// Create metadata task
    /// Create a task to extract metadata from files. Under the hood, this is using exiftool. 
    /// You can use this operation to get the number of pages of PDFs or to get the resolution of images/videos. 
    /// You can find an example result of of the metadata extraction of a PDF on the right.
    /// The metadata operation does not consume any minutes.
    /// </summary>
    /// <param name="api_key"></param>
    /// <param name="request"></param>
    /// <returns>
    /// The created task. You can find details about the task model response in the documentation about the show tasks endpoint.
    /// </returns>
    [Post("/metadata")]
    Task<TaskResponse> CreateMetadataTask([Header("Authorization")] string api_key, [Body(BodySerializationMethod.Serialized)] TaskMetadataData request);

    /// <summary>
    /// Create merge task
    /// Create a task to merge at least two files to one PDF. If input files are not PDFs yet, they are automatically converted to PDF.
    /// </summary>
    /// <param name="api_key"></param>
    /// <param name="request"></param>
    /// <returns>
    /// The created task. You can find details about the task model response in the documentation about the show tasks endpoint.
    /// </returns>
    [Post("/merge")]
    Task<TaskResponse> CreateMergeTask([Header("Authorization")] string api_key, [Body(BodySerializationMethod.Serialized)] TaskMergeData request);

    /// <summary>
    /// Create archive task
    /// Create a task to create a ZIP, RAR, 7Z, TAR, TAR.GZ or TAR.BZ2 archive.
    /// </summary>
    /// <param name="api_key"></param>
    /// <param name="request"></param>
    /// <returns>
    /// The created task. You can find details about the task model response in the documentation about the show tasks endpoint.
    /// </returns>
    [Post("/archive")]
    Task<TaskResponse> CreateArchiveTask([Header("Authorization")] string api_key, [Body(BodySerializationMethod.Serialized)] TaskArchiveData request);

    /// <summary>
    /// Create command task
    /// Create a task to execute a command. Currently, ffmpeg, imagemagick and graphicsmagick commands re supported.
    /// You can access the files from the input task in the /input/{taskName}/(For example: /input/import-1/) directory.
    /// All files that are created in the /output/ directory are available for following tasks(e.g.export tasks).
    /// </summary>
    /// <param name="api_key"></param>
    /// <param name="request"></param>
    /// <returns>
    /// The created task. You can find details about the task model response in the documentation about the show tasks endpoint.
    /// </returns>
    [Post("/command")]
    Task<TaskResponse> CreateCommandTask([Header("Authorization")] string api_key, [Body(BodySerializationMethod.Serialized)] TaskCommandData request);

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
