using Newtonsoft.Json;

namespace СloudСonvert.API.Models.TaskOperations
{
  public class TaskCommandBaseData : BaseOperation
  {
    /// <summary>
    /// The input task name(s) for this task.
    /// input: string | string[];
    /// </summary>
    [JsonProperty("input")]
    public dynamic Input { get; set; }

    [JsonProperty("engine", NullValueHandling = NullValueHandling.Ignore)]
    public string Engine { get; set; }

    [JsonProperty("engine_version", NullValueHandling = NullValueHandling.Ignore)]
    public string Engine_Version { get; set; }

    /// <summary>
    /// Capture the console output of the command and return it in the results object.
    /// </summary>
    [JsonProperty("capture_output", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Capture_Output { get; set; }

    /// <summary>
    /// Timeout in seconds after the task will be cancelled.
    /// </summary>
    [JsonProperty("timeout", NullValueHandling = NullValueHandling.Ignore)]
    public int? Timeout { get; set; }
  }
}
