using Newtonsoft.Json;

namespace СloudСonvert.API.Models
{
  public partial class BaseOperation
  {
    [JsonProperty("operation")]
    public string Operation { get; set; }
  }
}
