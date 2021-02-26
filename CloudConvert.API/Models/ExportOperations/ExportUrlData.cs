using Newtonsoft.Json;

namespace CloudConvert.API.Models.ExportOperations
{
  public class ExportUrlData
  {
    [JsonProperty("operation")]
    public static string Operation = "export/url";

    /// <summary>
    /// The input task name(s) for this task.
    /// input: string | string[];
    /// </summary>
    [JsonProperty("input")]
    public dynamic Input { get; set; }

    /// <summary>
    /// This option makes the export URLs return the Content-Disposition inline header, which tells browser to display the file instead of downloading it.
    /// </summary>
    [JsonProperty("inline", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Inline { get; set; }

    [JsonProperty("inline_additional", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Inline_Additional { get; set; }

    /// <summary>
    /// By default, multiple files will create multiple export URLs. When enabling this option, one export URL with a ZIP file will be created.
    /// </summary>
    [JsonProperty("archive_multiple_files", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Archive_Multiple_Files { get; set; }
  }
}
