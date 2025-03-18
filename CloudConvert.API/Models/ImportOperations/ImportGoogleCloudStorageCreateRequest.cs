using System.Text.Json.Serialization;

namespace CloudConvert.API.Models.ImportOperations
{
  public class ImportGoogleCloudStorageCreateRequest
  {
    [JsonPropertyName("operation")]
    public string Operation { get; } = "import/google-cloud-storage";

    [JsonPropertyName("project_id")]
    public string Project_Id { get; set; }

    [JsonPropertyName("bucket")]
    public string Bucket { get; set; }

    [JsonPropertyName("client_email")]
    public string Client_Email { get; set; }

    [JsonPropertyName("private_key")]
    public string Private_Key { get; set; }

    [JsonPropertyName("file")]
    public string File { get; set; }

    [JsonPropertyName("file_prefix")]
    public string File_Prefix { get; set; }

    [JsonPropertyName("filename")]
    public string Filename { get; set; }
  }
}
