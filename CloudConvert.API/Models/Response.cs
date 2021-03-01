using Newtonsoft.Json;

namespace CloudConvert.API.Models
{
  public partial class Response<T>
  {
    [JsonProperty("data")]
    public T Data { get; set; }
  }
}
