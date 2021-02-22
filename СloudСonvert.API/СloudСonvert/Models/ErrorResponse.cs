using Newtonsoft.Json;

namespace СloudСonvert.API.СloudСonvert.Models
{
  public partial class ErrorResponse
  {
    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("errors")]
    public object Errors { get; set; }
  }
}
