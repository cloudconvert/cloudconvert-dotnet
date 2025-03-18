using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CloudConvert.API.Models
{
  public partial class ListResponse<T>
  {
    [JsonPropertyName("data")]
    public List<T> Data { get; set; }

    [JsonPropertyName("links")]
    public ListResponseLinks Links { get; set; }

    [JsonPropertyName("meta")]
    public ListResponseMeta Meta { get; set; }
  }
}
