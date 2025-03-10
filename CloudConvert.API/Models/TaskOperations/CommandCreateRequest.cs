using System.Text.Json.Serialization;

namespace CloudConvert.API.Models.TaskOperations
{
  public class CommandCreateRequest
  {
    [JsonPropertyName("operation")]
    public string Operation { get; } = "command";

    /// <summary>
    /// The input task name(s) for this task.
    /// input: string | string[];
    /// </summary>
    [JsonPropertyName("input")]
    public object Input { get; set; }

    [JsonPropertyName("engine")]
    public string Engine { get; set; }

    [JsonPropertyName("engine_version")]
    public string Engine_Version { get; set; }

    /// <summary>
    /// Capture the console output of the command and return it in the results object.
    /// </summary>
    [JsonPropertyName("capture_output")]
    public bool? Capture_Output { get; set; }

    [JsonPropertyName("command")]
    public string Command { get; set; }

    [JsonPropertyName("arguments")]
    public string Arguments { get; set; }

    /// <summary>
    /// Timeout in seconds after the task will be cancelled.
    /// </summary>
    [JsonPropertyName("timeout")]
    public int? Timeout { get; set; }
  }
}
