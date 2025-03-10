using System.Text.Json.Serialization;

namespace CloudConvert.API.Models.ExportOperations
{
  public class ExportGoogleCloudStorageCreateRequest
  {
    [JsonPropertyName("operation")]
    public string Operation { get; } = "export/google-cloud-storage";

    /// <summary>
    /// The input task name(s) for this task.
    /// input: string | string[];
    /// </summary>
    [JsonPropertyName("input")]
    public object Input { get; set; }

    [JsonPropertyName("project_id")]
    public string ProjectId { get; set; }

    [JsonPropertyName("bucket")]
    public string Bucket { get; set; }

    [JsonPropertyName("client_email")]
    public string Client_Email { get; set; }

    [JsonPropertyName("private_key")]
    public string Private_Key { get; set; }

    [JsonPropertyName("file")]
    public string File { get; set; }

    [JsonPropertyName("file_prefix")]
    public string File_Prefix { get; set; }
  }
}
