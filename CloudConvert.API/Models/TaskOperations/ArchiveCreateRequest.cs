using System.Text.Json.Serialization;

namespace CloudConvert.API.Models.TaskOperations
{
  public class ArchiveCreateRequest
  {
    [JsonPropertyName("operation")]
    public string Operation { get; } = "archive";

    /// <summary>
    /// The input task name(s) for this task.
    /// input: string | string[];
    /// </summary>
    [JsonPropertyName("input")]
    public object Input { get; set; }

    [JsonPropertyName("output_format")]
    public string Output_Format { get; set; }

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
  }
}
