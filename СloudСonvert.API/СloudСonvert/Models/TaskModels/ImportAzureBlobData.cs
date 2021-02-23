using Newtonsoft.Json;

namespace СloudСonvert.API.СloudСonvert.Models.TaskModels
{
  public class ImportAzureBlobData : Import
  {
    [JsonProperty("storage_account")]
    public string Storage_Account { get; set; }

    [JsonProperty("storage_access_key")]
    public string Storage_Access_Key { get; set; }

    [JsonProperty("sas_token")]
    public string Sas_Token { get; set; }

    [JsonProperty("container")]
    public string Container { get; set; }

    [JsonProperty("blob")]
    public string Blob { get; set; }

    [JsonProperty("blob_prefix")]
    public string Blob_Prefix { get; set; }

    [JsonProperty("filename")]
    public string Filename { get; set; }
  }
}
