using System.Collections.Generic;
using Newtonsoft.Json;

namespace CloudConvert.API.Models.TaskOperations
{
  public class MetadataWriteCreateRequest
  {
    [JsonProperty("operation")]
    public static string Operation = "metadata/write";

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

    [JsonProperty("timeout", NullValueHandling = NullValueHandling.Ignore)]
    public int? Timeout { get; set; }

    [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string, string> Metadata { get; set; }

    [JsonExtensionData]
    [JsonProperty("options", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string, object> Options { get; set; }
  }
}
