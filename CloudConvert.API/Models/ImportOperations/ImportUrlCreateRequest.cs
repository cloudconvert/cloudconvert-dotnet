using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CloudConvert.API.Models.ImportOperations
{
  public class ImportUrlCreateRequest
  {
    [JsonPropertyName("operation")]
    public string Operation { get; } = "import/url";

    [JsonPropertyName("url")]
    public string Url { get; set; }

    /// <summary>
    /// The filename of the input file, including extension. If none provided we will try to detect the filename from the URL.
    /// </summary>
    [JsonPropertyName("filename")]
    public string Filename { get; set; }

    [JsonPropertyName("headers")]
    public Dictionary<string, string> Headers { get; set; }
  }
}
