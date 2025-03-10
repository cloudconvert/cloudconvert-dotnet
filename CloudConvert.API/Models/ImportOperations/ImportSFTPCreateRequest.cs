using System.Text.Json.Serialization;

namespace CloudConvert.API.Models.ImportOperations
{
  public class ImportSFTPCreateRequest
  {
    [JsonPropertyName("operation")]
    public string Operation { get; } = "import/sftp";

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

    [JsonPropertyName("filename")]
    public string Filename { get; set; }
  }
}
