using Newtonsoft.Json;

namespace СloudСonvert.API.СloudСonvert.Models.TaskModels
{
  public partial class TaskResponse
  {
    [JsonProperty("data")]
    public TaskCC Data { get; set; }
  }
}
