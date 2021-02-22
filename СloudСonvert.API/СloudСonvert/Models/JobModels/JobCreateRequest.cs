using Newtonsoft.Json;

namespace СloudСonvert.API.СloudСonvert.Models.JobModels
{
  public partial class JobCreateRequest
  {
    /// <summary>
    /// The example on the right consists of three tasks: import-my-file, convert-my-file and export-my-file. 
    /// You can name these tasks however you want, but only alphanumeric characters, - and _ are allowed in the task names.
    /// 
    /// Each task has a operation, which is the endpoint for creating the task(for example: convert, import/s3 or export/s3). 
    /// The other parameters are the same as for creating the task using their direct endpoint.
    /// The input parameter allows it to directly reference the name of another task, created with the same job request.
    /// </summary>
    [JsonProperty("tasks")]
    public dynamic Tasks { get; set; }

    /// <summary>
    /// An arbitrary string to identify the job. Does not have any effect and can be used to associate the job with an ID in your application.
    /// </summary>
    [JsonProperty("tag")]
    public string Tag { get; set; }
  }
}
