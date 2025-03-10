using System.Collections.Generic;
using System.Text.Json.Serialization;
using CloudConvert.API.Models.Enums;

namespace CloudConvert.API.Models.TaskOperations
{
  public class OptimizeCreateRequest
  {
    [JsonPropertyName("operation")]
    public string Operation { get; } = "optimize";

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
    public OptimizeInputFormat? Input_Format { get; set; }

    [JsonPropertyName("engine")]
    public string Engine { get; set; }

    [JsonPropertyName("engine_version")]
    public string Engine_Version { get; set; }

    /// <summary>
    /// Choose a filename (including extension) for the output file.
    /// </summary>
    [JsonPropertyName("filename")]
    public string Filename { get; set; }

    [JsonPropertyName("quality")]
    public int? Quality { get; set; }

    [JsonPropertyName("profile")]
    public OptimizeProfile? Profile { get; set; }

    /// <summary>
    /// Timeout in seconds after the task will be cancelled.
    /// </summary>
    [JsonPropertyName("timeout")]
    public int? Timeout { get; set; }

    /// <summary>
    /// Conversion and engine specific options. Depends on input_format and output_format.
    /// </summary>
    [JsonExtensionData]
    [JsonPropertyName("options")]
    public Dictionary<string, object> Options { get; set; }
  }
}
