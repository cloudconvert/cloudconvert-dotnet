using Newtonsoft.Json;

namespace СloudСonvert.API.СloudСonvert.Models.JobModels
{
  public partial class JobResponse
  {
    [JsonProperty("data")]
    public Job Data { get; set; }
  }
}
