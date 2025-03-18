using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CloudConvert.API.Models.TaskOperations
{
  public class MetadataWriteCreateRequest
  {
    [JsonPropertyName("operation")]
    public string Operation { get; } = "metadata/write";

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

    [JsonPropertyName("timeout")]
    public int? Timeout { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, string> Metadata { get; set; }

    /// <summary>
    /// Conversion and engine specific options. Depends on input_format and output_format.
    /// </summary>
    [JsonExtensionData]
    [JsonPropertyName("options")]
    public Dictionary<string, object> Options { get; set; }
  }
}
