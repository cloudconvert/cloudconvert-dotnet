using System;
using System.Text.Json.Serialization;

namespace CloudConvert.API.Models.TaskModels
{
  public partial class UploadForm
  {
    [JsonPropertyName("url")]
    public Uri Url { get; set; }

    [JsonPropertyName("parameters")]
    public object Parameters { get; set; }
  }
}
