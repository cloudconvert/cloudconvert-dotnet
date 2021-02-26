using System;
using Newtonsoft.Json;

namespace CloudConvert.API.Models.TaskModels
{
  public partial class FileTask
  {
    [JsonProperty("filename")]
    public string Filename { get; set; }

    [JsonProperty("size")]
    public long Size { get; set; }

    [JsonProperty("url")]
    public Uri Url { get; set; }
  }
}
