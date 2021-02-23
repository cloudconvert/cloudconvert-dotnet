using Newtonsoft.Json;

namespace СloudСonvert.API.Models.TaskOperations
{
  public class TaskConvertData : BaseOperation
  {
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

    [JsonProperty("output_format")]
    public string Output_Format { get; set; }

    [JsonProperty("page_range", NullValueHandling = NullValueHandling.Ignore)]
    public string Page_Range { get; set; }

    [JsonProperty("optimize_print", NullValueHandling = NullValueHandling.Ignore)]
    public bool Optimize_Print { get; set; }

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

  }
}
