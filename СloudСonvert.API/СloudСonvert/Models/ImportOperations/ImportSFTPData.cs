using Newtonsoft.Json;

namespace СloudСonvert.API.СloudСonvert.Models.ImportOperations
{
  public class ImportSFTPData : BaseOperation
  {
    [JsonProperty("host")]
    public string Host { get; set; }

    [JsonProperty("port")]
    public string Port { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("password")]
    public string Password { get; set; }

    [JsonProperty("private_key")]
    public string Private_Key { get; set; }

    [JsonProperty("file")]
    public string File { get; set; }

    [JsonProperty("path")]
    public string Path { get; set; }

    [JsonProperty("filename")]
    public string Filename { get; set; }
  }
}
