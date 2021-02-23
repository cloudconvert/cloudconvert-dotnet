using System.Collections.Generic;
using Newtonsoft.Json;

namespace СloudСonvert.API.Models.JobModels
{
  public partial class JobsResponse
  {
    [JsonProperty("data")]
    public List<JobCC> Data { get; set; }

    [JsonProperty("links")]
    public Links Links { get; set; }

    [JsonProperty("meta")]
    public Meta Meta { get; set; }
  }
}
