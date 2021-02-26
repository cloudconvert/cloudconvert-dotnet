using System.Collections.Generic;
using Newtonsoft.Json;

namespace CloudConvert.API.Models.TaskModels
{
  public partial class ResultTask
  {
    [JsonProperty("form")]
    public Form Form { get; set; }

    [JsonProperty("files")]
    public List<FileTask> Files { get; set; }
  }
}
