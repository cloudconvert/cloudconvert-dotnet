using System.Text.Json.Serialization;

namespace CloudConvert.API.Models
{
  public partial class Response<T>
  {
    [JsonPropertyName("data")]
    public T Data { get; set; }
  }
}
