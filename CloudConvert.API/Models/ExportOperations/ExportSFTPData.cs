using Newtonsoft.Json;

namespace CloudConvert.API.Models.ExportOperations
{
  public class ExportSFTPData
  {
    [JsonProperty("operation")]
    public static string Operation = "export/sftp";
    /// <summary>
    /// The input task name(s) for this task.
    /// input: string | string[];
    /// </summary>
    [JsonProperty("input")]
    public dynamic Input { get; set; }

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
  }
}
