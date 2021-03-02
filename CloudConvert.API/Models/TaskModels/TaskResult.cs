using System.Collections.Generic;
using Newtonsoft.Json;

namespace CloudConvert.API.Models.TaskModels
{
  public partial class TaskResult
  {
    [JsonProperty("form")]
    public UploadForm Form { get; set; }

    [JsonProperty("files")]
    public List<TaskResultFile> Files { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, object> Metadata { get; set; }
  }
}
