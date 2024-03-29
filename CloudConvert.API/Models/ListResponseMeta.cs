using System;
using Newtonsoft.Json;

namespace CloudConvert.API.Models
{
  public partial class ListResponseMeta
  {
    [JsonProperty("current_page")]
    public int? Current_Page { get; set; }

    [JsonProperty("from")]
    public int? From { get; set; }

    [JsonProperty("path")]
    public Uri Path { get; set; }

    [JsonProperty("per_page")]
    public int? Per_Page { get; set; }

    [JsonProperty("to")]
    public int? To { get; set; }
  }
}
