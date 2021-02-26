using Newtonsoft.Json;

namespace CloudConvert.API.Models.TaskModels
{
  public partial class TaskResponse
  {
    [JsonProperty("data")]
    public TaskCC Data { get; set; }
  }
}
