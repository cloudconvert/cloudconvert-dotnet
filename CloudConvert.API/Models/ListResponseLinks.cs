using System;
using Newtonsoft.Json;

namespace CloudConvert.API.Models
{
  public partial class Links
  {
    [JsonProperty("first")]
    public Uri First { get; set; }

    [JsonProperty("last")]
    public Uri Last { get; set; }

    [JsonProperty("prev")]
    public Uri Prev { get; set; }

    [JsonProperty("next")]
    public Uri Next { get; set; }
  }
}
