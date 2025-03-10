using System.Text.Json.Serialization;

namespace CloudConvert.API.Models.ImportOperations
{
  public class ImportAzureBlobCreateRequest
  {
    [JsonPropertyName("operation")]
    public string Operation { get; } = "import/azure/blob";

    [JsonPropertyName("storage_account")]
    public string Storage_Account { get; set; }

    [JsonPropertyName("storage_access_key")]
    public string Storage_Access_Key { get; set; }

    [JsonPropertyName("sas_token")]
    public string Sas_Token { get; set; }

    [JsonPropertyName("container")]
    public string Container { get; set; }

    [JsonPropertyName("blob")]
    public string Blob { get; set; }

    [JsonPropertyName("blob_prefix")]
    public string Blob_Prefix { get; set; }

    [JsonPropertyName("filename")]
    public string Filename { get; set; }
  }
}
