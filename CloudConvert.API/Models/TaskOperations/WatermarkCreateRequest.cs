using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CloudConvert.API.Models.TaskOperations
{
  public class WatermarkCreateRequest
  {
    [JsonPropertyName("operation")]
    public string Operation { get; } = "watermark";

    /// <summary>
    /// The input task name(s) for this task.
    /// input: string | string[];
    /// </summary>
    [JsonPropertyName("input")]
    public object Input { get; set; }

    /// <summary>
    /// If not set, the extension of the input file is used as input format
    /// </summary>
    [JsonPropertyName("input_format")]
    public string Input_Format { get; set; }

    [JsonPropertyName("engine")]
    public string Engine { get; set; }

    [JsonPropertyName("engine_version")]
    public string Engine_Version { get; set; }

    /// <summary>
    /// Choose a filename (including extension) for the output file.
    /// </summary>
    [JsonPropertyName("filename")]
    public string Filename { get; set; }

    /// <summary>
    /// Timeout in seconds after the task will be cancelled.
    /// </summary>
    [JsonPropertyName("timeout")]
    public int? Timeout { get; set; }

    /// <summary>
    /// Conversion and engine specific options. Depends on input_format and output_format.
    /// Select input and output format above to show additional conversion options.
    /// </summary>
    [JsonExtensionData]
    [JsonPropertyName("options")]
    public Dictionary<string, object> Options { get; set; }
  }
}
