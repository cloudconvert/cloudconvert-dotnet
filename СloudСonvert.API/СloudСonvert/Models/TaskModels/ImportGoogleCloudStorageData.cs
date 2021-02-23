using Newtonsoft.Json;

namespace СloudСonvert.API.СloudСonvert.Models.TaskModels
{
  public class ImportGoogleCloudStorageData : Import
  {
    [JsonProperty("project_id")]
    public string Project_Id { get; set; }

    [JsonProperty("bucket")]
    public string Bucket { get; set; }

    [JsonProperty("client_email")]
    public string Client_Email { get; set; }

    [JsonProperty("private_key")]
    public string Private_Key { get; set; }

    [JsonProperty("file")]
    public string File { get; set; }

    [JsonProperty("file_prefix")]
    public string File_Prefix { get; set; }

    [JsonProperty("filename")]
    public string Filename { get; set; }

  }
}
