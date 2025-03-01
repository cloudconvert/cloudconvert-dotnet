using Newtonsoft.Json;
using System.Collections.Generic;

namespace CloudConvert.API.Models.TaskOperations
{
  public class WatermarkCreateRequest
  {
    [JsonProperty("operation")]
    public static string Operation = "watermark";

    /// <summary>
    /// The input task name(s) for this task.
    /// input: string | string[];
    /// </summary>
    [JsonProperty("input")]
    public dynamic Input { get; set; }

    /// <summary>
    /// If not set, the extension of the input file is used as input format
    /// </summary>
    [JsonProperty("input_format", NullValueHandling = NullValueHandling.Ignore)]
    public string Input_Format { get; set; }


    [JsonProperty("engine", NullValueHandling = NullValueHandling.Ignore)]
    public string Engine { get; set; }

    [JsonProperty("engine_version", NullValueHandling = NullValueHandling.Ignore)]
    public string Engine_Version { get; set; }

    /// <summary>
    /// Choose a filename (including extension) for the output file.
    /// </summary>
    [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
    public string Filename { get; set; }

    /// <summary>
    /// Timeout in seconds after the task will be cancelled.
    /// </summary>
    [JsonProperty("timeout", NullValueHandling = NullValueHandling.Ignore)]
    public int? Timeout { get; set; }

    /// <summary>
    /// Conversion and engine specific options. Depends on input_format and output_format.
    /// Select input and output format above to show additional conversion options.
    /// </summary>
    [JsonExtensionData]
    [JsonProperty("options", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string, object> Options { get; set; }

  }
}
