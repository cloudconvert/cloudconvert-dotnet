using System.Text.Json;
using System.Text.Json.Serialization;

namespace CloudConvert.API;

public class DefaultJsonSerializerOptions
{
  public static readonly JsonSerializerOptions SerializerOptions = new()
  {
    Converters = { new JsonStringEnumConverter() },
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
  };
}
