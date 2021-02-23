using Newtonsoft.Json;

namespace СloudСonvert.API.СloudСonvert.Models.TaskModels
{
  public partial class Base
  {
    [JsonProperty("operation")]
    public string Operation { get; set; }
  }
}
