using System.Text.Json.Serialization;

namespace CloudConvert.API.Models.ExportOperations
{
  public class ExportSFTPCreateRequest
  {
    [JsonPropertyName("operation")]
    public string Operation { get; } = "export/sftp";

    /// <summary>
    /// The input task name(s) for this task.
    /// input: string | string[];
    /// </summary>
    [JsonPropertyName("input")]
    public object Input { get; set; }

    [JsonPropertyName("host")]
    public string Host { get; set; }

    [JsonPropertyName("port")]
    public string Port { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    [JsonPropertyName("private_key")]
    public string Private_Key { get; set; }

    [JsonPropertyName("file")]
    public string File { get; set; }

    [JsonPropertyName("path")]
    public string Path { get; set; }
  }
}
