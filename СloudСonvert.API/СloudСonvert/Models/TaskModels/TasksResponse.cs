using System.Collections.Generic;
using Newtonsoft.Json;
using СloudСonvert.API.СloudСonvert.Models.JobModels;

namespace СloudСonvert.API.СloudСonvert.Models.TaskModels
{
  public partial class TasksResponse
  {
    [JsonProperty("data")]
    public List<TaskCC> Data { get; set; }

    [JsonProperty("links")]
    public Links Links { get; set; }

    [JsonProperty("meta")]
    public Meta Meta { get; set; }
  }
}
