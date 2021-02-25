using Newtonsoft.Json;

namespace СloudСonvert.API.Models.ImportOperations
{
  public class ImportOpenStackData
  {
    [JsonProperty("operation")]
    public static string Operation = "import/openstack";

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
    public string File_Prefix { get; set; }

    [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
    public string Filename { get; set; }
  }
}
