using System.Text.Json.Serialization;

namespace CloudConvert.API.Models.ExportOperations
{
  public class ExportOpenStackCreateRequest
  {
    [JsonPropertyName("operation")]
    public string Operation { get; } = "export/openstack";

    /// <summary>
    /// The input task name(s) for this task.
    /// input: string | string[];
    /// </summary>
    [JsonPropertyName("input")]
    public object Input { get; set; }

    [JsonPropertyName("auth_url")]
    public string Auth_Url { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    [JsonPropertyName("region")]
    public string Region { get; set; }

    [JsonPropertyName("container")]
    public string Container { get; set; }

    [JsonPropertyName("file")]
    public string File { get; set; }

    [JsonPropertyName("file_prefix")]
    public string FilePrefix { get; set; }
  }
}
