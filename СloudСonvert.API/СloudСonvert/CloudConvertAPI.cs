using System.Threading.Tasks;
using СloudСonvert.API.СloudСonvert.Models.JobModels;

namespace СloudСonvert.API.СloudСonvert
{
  public class CloudConvertAPI
  {
    readonly string _apiUrl;
    readonly ICloudConvertServiceWebApi _api;
    readonly string _api_key = "Bearer ";

    public CloudConvertAPI()
    {
      _api = CloudConvertServiceWebApiFactory.CreateWebApi(_apiUrl);
    }

    public CloudConvertAPI(string url, string api_key)
    {
      _apiUrl = url;
      _api_key += api_key;
      _api = CloudConvertServiceWebApiFactory.CreateWebApi(_apiUrl);
    }

    public Task<JobsResponse> GetAllJobsAsync(JobFilter jobFilter) => _api.GetAllJobs(_api_key, jobFilter.Status, jobFilter.Tag, jobFilter.Include, jobFilter.PerPage, jobFilter.Page);

    public Task<JobResponse> GetJobAsync(string id) => _api.GetJob(_api_key, id);
  }
}
