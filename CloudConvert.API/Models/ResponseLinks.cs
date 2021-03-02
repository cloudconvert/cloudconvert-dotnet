using System;
using Newtonsoft.Json;

namespace CloudConvert.API.Models
{
  public partial class ResponseLinks
  {
    [JsonProperty("self")]
    public Uri Self { get; set; }
  }
}
