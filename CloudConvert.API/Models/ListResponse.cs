using System.Collections.Generic;
using CloudConvert.API.Models.JobModels;
using Newtonsoft.Json;

namespace CloudConvert.API.Models
{
  public partial class ListResponse<T>
  {
    [JsonProperty("data")]
    public List<T> Data { get; set; }

    [JsonProperty("links")]
    public Links Links { get; set; }

    [JsonProperty("meta")]
    public Meta Meta { get; set; }
  }
}
