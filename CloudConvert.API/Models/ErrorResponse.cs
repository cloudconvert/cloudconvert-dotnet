using System.Text.Json.Serialization;

namespace CloudConvert.API.Models
{
  public partial class ErrorResponse
  {
    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("errors")]
    public object Errors { get; set; }
  }
}
