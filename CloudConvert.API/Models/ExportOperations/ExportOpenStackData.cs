using Newtonsoft.Json;

namespace CloudConvert.API.Models.ExportOperations
{
  public class ExportOpenStackData
  {
    [JsonProperty("operation")]
    public static string Operation = "export/openstack";

    /// <summary>
    /// The input task name(s) for this task.
    /// input: string | string[];
    /// </summary>
    [JsonProperty("input")]
    public dynamic Input { get; set; }

    [JsonProperty("auth_url")]
    public string Auth_Url { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("password")]
    public string Password { get; set; }

    [JsonProperty("region")]
    public string Region { get; set; }

    [JsonProperty("container")]
    public string Container { get; set; }

    [JsonProperty("file", NullValueHandling = NullValueHandling.Ignore)]
    public string File { get; set; }

    [JsonProperty("file_prefix", NullValueHandling = NullValueHandling.Ignore)]
    public string FilePrefix { get; set; }
  }
}
