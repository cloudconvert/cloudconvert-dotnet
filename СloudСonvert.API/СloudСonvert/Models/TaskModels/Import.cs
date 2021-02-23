using Newtonsoft.Json;

namespace СloudСonvert.API.СloudСonvert.Models.TaskModels
{
  public partial class Import
  {
    [JsonProperty("operation")]
    public string Operation { get; set; }
  }
}
