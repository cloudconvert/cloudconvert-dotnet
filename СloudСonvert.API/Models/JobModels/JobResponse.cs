using Newtonsoft.Json;

namespace СloudСonvert.API.Models.JobModels
{
  public partial class JobResponse
  {
    [JsonProperty("data")]
    public JobCC Data { get; set; }
  }
}
