using System.Collections.Generic;
using Newtonsoft.Json;

namespace CloudConvert.API.Models
{
  public partial class ListResponse<T>
  {
    [JsonProperty("data")]
    public List<T> Data { get; set; }

    [JsonProperty("links")]
    public ListResponseLinks Links { get; set; }

    [JsonProperty("meta")]
    public ListResponseMeta Meta { get; set; }
  }
}
