using System.Text.Json.Serialization;

namespace CloudConvert.API.Models.ExportOperations
{
  public class ExportUrlCreateRequest
  {
    [JsonPropertyName("operation")]
    public string Operation { get; } = "export/url";

    /// <summary>
    /// The input task name(s) for this task.
    /// input: string | string[];
    /// </summary>
    [JsonPropertyName("input")]
    public object Input { get; set; }

    /// <summary>
    /// This option makes the export URLs return the Content-Disposition inline header, which tells browser to display the file instead of downloading it.
    /// </summary>
    [JsonPropertyName("inline")]
    public bool? Inline { get; set; }

    [JsonPropertyName("inline_additional")]
    public bool? Inline_Additional { get; set; }

    /// <summary>
    /// By default, multiple files will create multiple export URLs. When enabling this option, one export URL with a ZIP file will be created.
    /// </summary>
    [JsonPropertyName("archive_multiple_files")]
    public bool? Archive_Multiple_Files { get; set; }
  }
}
