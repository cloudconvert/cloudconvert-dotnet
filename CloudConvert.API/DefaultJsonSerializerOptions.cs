using System.Text.Json.Serialization;
using System.Text.Json;

namespace CloudConvert.API
{
  public class DefaultJsonSerializerOptions
  {
    public static readonly JsonSerializerOptions SerializerOptions = new()
    {
      Converters = { new JsonStringEnumConverter() },
      DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
  }
}
