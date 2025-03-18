using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CloudConvert.API.Models.TaskModels
{
  public partial class TaskResult
  {
    [JsonPropertyName("form")]
    public UploadForm Form { get; set; }

    [JsonPropertyName("files")]
    public List<TaskResultFile> Files { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, object> Metadata { get; set; }
  }
}
