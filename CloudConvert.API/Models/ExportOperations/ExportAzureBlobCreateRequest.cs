using System.Text.Json.Serialization;

namespace CloudConvert.API.Models.ExportOperations
{
  public class ExportAzureBlobCreateRequest
  {
    [JsonPropertyName("operation")]
    public string Operation { get; } = "export/azure/blob";

    /// <summary>
    /// The input task name(s) for this task.
    /// input: string | string[];
    /// </summary>
    [JsonPropertyName("input")]
    public object Input { get; set; }

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
  }
}
