using System.Threading.Tasks;
using Refit;
using СloudСonvert.API.СloudСonvert.Models.Enums;
using СloudСonvert.API.СloudСonvert.Models.JobModels;

namespace СloudСonvert.API.СloudСonvert
{
  public interface ICloudConvertServiceWebApi
  {
    /// <summary>
    /// Lists jobs
    /// </summary>
    /// <param name="api_key"></param>
    /// <param name="status"></param>
    /// <param name="tag"></param>
    /// <param name="include"></param>
    /// <param name="perPage"></param>
    /// <param name="page"></param>
    /// <returns></returns>
    [Get("/jobs?filter[status]={status}&filter[tag]={tag}&include={include}&per_page={perPage}&page={page}")]
    Task<JobsResponse> GetAllJobs([Header("Authorization")] string api_key, JobStatus? status = null, string tag = null, string include = null, int? perPage = null, int? page = null);

    /// <summary>
    /// Show a job
    /// </summary>
    /// <param name="api_key"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [Get("/jobs/{id}")]
    Task<JobResponse> GetJob([Header("Authorization")] string api_key, string id);

    /// <summary>
    /// Wait for a job
    /// </summary>
    /// <param name="api_key"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [Get("/jobs/{id}/wait")]
    Task<JobResponse> WaitJob([Header("Authorization")] string api_key, string id);

    /// <summary>
    /// Delete a job
    /// </summary>
    /// <param name="api_key"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [Delete("/jobs/{id}")]
    Task DeleteJob([Header("Authorization")] string api_key, string id);
  }
}
