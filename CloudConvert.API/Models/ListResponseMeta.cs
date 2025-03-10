using System;
using System.Text.Json.Serialization;

namespace CloudConvert.API.Models
{
  public partial class ListResponseMeta
  {
    [JsonPropertyName("current_page")]
    public int? Current_Page { get; set; }

    [JsonPropertyName("from")]
    public int? From { get; set; }

    [JsonPropertyName("path")]
    public Uri Path { get; set; }

    [JsonPropertyName("per_page")]
    public int? Per_Page { get; set; }

    [JsonPropertyName("to")]
    public int? To { get; set; }
  }
}
