using Newtonsoft.Json;

namespace СloudСonvert.API.Models.ExportOperations
{
  public class ExportGoogleCloudStorageData : BaseOperation
  {
    /// <summary>
    /// The input task name(s) for this task.
    /// input: string | string[];
    /// </summary>
    [JsonProperty("input")]
    public dynamic Input { get; set; }

    [JsonProperty("project_id")]
    public string ProjectId { get; set; }

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
  }
}
