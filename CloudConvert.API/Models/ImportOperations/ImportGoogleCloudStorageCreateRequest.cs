using Newtonsoft.Json;

namespace CloudConvert.API.Models.ImportOperations
{
  public class ImportGoogleCloudStorageCreateRequest
  {
    [JsonProperty("operation")]
    public static string Operation = "import/google-cloud-storage";

    [JsonProperty("project_id")]
    public string Project_Id { get; set; }

    [JsonProperty("bucket")]
    public string Bucket { get; set; }

    [JsonProperty("client_email")]
    public string Client_Email { get; set; }

    [JsonProperty("private_key")]
    public string Private_Key { get; set; }

    [JsonProperty("file", NullValueHandling = NullValueHandling.Ignore)]
    public string File { get; set; }

    [JsonProperty("file_prefix", NullValueHandling = NullValueHandling.Ignore)]
    public string File_Prefix { get; set; }

    [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
    public string Filename { get; set; }

  }
}
