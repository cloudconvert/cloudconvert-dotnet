using System.Text.Json.Serialization;

namespace CloudConvert.API.Models.ImportOperations
{
  public class ImportOpenStackCreateRequest
  {
    [JsonPropertyName("operation")]
    public string Operation { get; } = "import/openstack";

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
    public string File_Prefix { get; set; }

    [JsonPropertyName("filename")]
    public string Filename { get; set; }
  }
}
