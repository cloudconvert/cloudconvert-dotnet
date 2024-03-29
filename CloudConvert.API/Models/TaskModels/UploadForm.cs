using System;
using Newtonsoft.Json;

namespace CloudConvert.API.Models.TaskModels
{
  public partial class UploadForm
  {
    [JsonProperty("url")]
    public Uri Url { get; set; }

    [JsonProperty("parameters")]
    public object Parameters { get; set; }
  }
}
