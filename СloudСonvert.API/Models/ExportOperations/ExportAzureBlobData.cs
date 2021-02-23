using Newtonsoft.Json;

namespace СloudСonvert.API.Models.ExportOperations
{
  public class ExportAzureBlobData : BaseOperation
  {
    /// <summary>
    /// The input task name(s) for this task.
    /// input: string | string[];
    /// </summary>
    [JsonProperty("input")]
    public dynamic Input { get; set; }

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
  }
}
