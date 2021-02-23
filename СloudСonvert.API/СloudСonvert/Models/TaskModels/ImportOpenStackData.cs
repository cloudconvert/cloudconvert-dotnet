using Newtonsoft.Json;

namespace СloudСonvert.API.СloudСonvert.Models.TaskModels
{
  public class ImportOpenStackData : Base
  {
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

    [JsonProperty("file")]
    public string File { get; set; }

    [JsonProperty("file_prefix")]
    public string File_Prefix { get; set; }

    [JsonProperty("filename")]
    public string Filename { get; set; }
  }
}
