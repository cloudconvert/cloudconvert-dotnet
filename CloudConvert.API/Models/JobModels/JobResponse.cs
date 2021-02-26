using Newtonsoft.Json;

namespace CloudConvert.API.Models.JobModels
{
  public partial class JobResponse
  {
    [JsonProperty("data")]
    public JobCC Data { get; set; }
  }
}
