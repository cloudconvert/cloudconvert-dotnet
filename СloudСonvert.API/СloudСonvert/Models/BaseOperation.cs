using Newtonsoft.Json;

namespace СloudСonvert.API.СloudСonvert.Models
{
  public partial class BaseOperation
  {
    [JsonProperty("operation")]
    public string Operation { get; set; }
  }
}
