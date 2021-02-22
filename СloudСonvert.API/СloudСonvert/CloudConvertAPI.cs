using System.Threading.Tasks;
using СloudСonvert.API.СloudСonvert.Models.JobModels;
using СloudСonvert.API.СloudСonvert.Models.TaskModels;

namespace СloudСonvert.API.СloudСonvert
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

    public Task<JobsResponse> GetAllJobsAsync(JobFilter jobFilter) => _api.GetAllJobs(_api_key, jobFilter.Status, jobFilter.Tag, jobFilter.Include, jobFilter.PerPage, jobFilter.Page);

    public Task<JobResponse> GetJobAsync(string id) => _api.GetJob(_api_key, id);

    public Task<JobResponse> WaitJobAsync(string id) => _api.WaitJob(_api_key, id);

    public Task DeleteJobAsync(string id) => _api.DeleteJob(_api_key, id);

    #endregion

    #region Tasks

    public Task<TasksResponse> GetAllTasksAsync(TaskFilter jobFilter) => _api.GetAllTasks(_api_key, jobFilter.JobId, jobFilter.Status, jobFilter.Operation, jobFilter.Include, jobFilter.PerPage, jobFilter.Page);

    public Task<TaskResponse> GetTaskAsync(string id) => _api.GetTask(_api_key, id);

    public Task<TaskResponse> WaitTaskAsync(string id) => _api.WaitTask(_api_key, id);

    public Task DeleteTaskAsync(string id) => _api.DeleteTask(_api_key, id);

    #endregion
  }
}
