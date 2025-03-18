using System;
using System.Text.Json.Serialization;

namespace CloudConvert.API.Models
{
  public partial class ListResponseLinks
  {
    [JsonPropertyName("first")]
    public Uri First { get; set; }

    [JsonPropertyName("last")]
    public Uri Last { get; set; }

    [JsonPropertyName("prev")]
    public Uri Prev { get; set; }

    [JsonPropertyName("next")]
    public Uri Next { get; set; }
  }
}
