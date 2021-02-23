using System.Collections.Generic;
using Newtonsoft.Json;

namespace СloudСonvert.API.Models.TaskModels
{
  public partial class Result
  {
    [JsonProperty("files")]
    public List<File> Files { get; set; }
  }
}
