using Newtonsoft.Json;

namespace CloudConvert.API.Models.ImportOperations
{
  public class ImportSFTPData
  {
    [JsonProperty("operation")]
    public static string Operation = "import/sftp";

    [JsonProperty("host")]
    public string Host { get; set; }

    [JsonProperty("port", NullValueHandling = NullValueHandling.Ignore)]
    public string Port { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("password", NullValueHandling = NullValueHandling.Ignore)]
    public string Password { get; set; }

    [JsonProperty("private_key", NullValueHandling = NullValueHandling.Ignore)]
    public string Private_Key { get; set; }

    [JsonProperty("file", NullValueHandling = NullValueHandling.Ignore)]
    public string File { get; set; }

    [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
    public string Path { get; set; }

    [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
    public string Filename { get; set; }
  }
}
