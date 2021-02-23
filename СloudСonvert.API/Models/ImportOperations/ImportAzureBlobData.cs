using Newtonsoft.Json;

namespace СloudСonvert.API.Models.ImportOperations
{
  public class ImportAzureBlobData : BaseOperation
  {
    [JsonProperty("storage_account")]
    public string Storage_Account { get; set; }

    [JsonProperty("storage_access_key", NullValueHandling = NullValueHandling.Ignore)]
    public string Storage_Access_Key { get; set; }

    [JsonProperty("sas_token", NullValueHandling = NullValueHandling.Ignore)]
    public string Sas_Token { get; set; }

    [JsonProperty("container")]
    public string Container { get; set; }

    [JsonProperty("blob", NullValueHandling = NullValueHandling.Ignore)]
    public string Blob { get; set; }

    [JsonProperty("blob_prefix", NullValueHandling = NullValueHandling.Ignore)]
    public string Blob_Prefix { get; set; }

    [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
    public string Filename { get; set; }
  }
}
