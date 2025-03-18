using System;
using System.Text.Json.Serialization;

namespace CloudConvert.API.Models
{
  public partial class ResponseLinks
  {
    [JsonPropertyName("self")]
    public Uri Self { get; set; }
  }
}
