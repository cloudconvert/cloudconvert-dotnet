using System;
using System.Text.Json.Serialization;

namespace CloudConvert.API.Models.TaskModels
{
  public partial class TaskResultFile
  {
    [JsonPropertyName("filename")]
    public string Filename { get; set; }

    [JsonPropertyName("size")]
    public long Size { get; set; }

    [JsonPropertyName("url")]
    public Uri Url { get; set; }
  }
}
