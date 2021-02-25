using Newtonsoft.Json;

namespace СloudСonvert.API.Models.TaskModels
{
  public partial class TaskParameters
  {
    [JsonProperty("acl")]
    public string Acl { get; set; }

    [JsonProperty("key")]
    public string Key { get; set; }

    [JsonProperty("success_action_status")]
    public string SuccessActionStatus { get; set; }

    [JsonProperty("X-Amz-Credential")]
    public string XAmzCredential { get; set; }

    [JsonProperty("X-Amz-Algorithm")]
    public string XAmzAlgorithm { get; set; }

    [JsonProperty("X-Amz-Date")]
    public string XAmzDate { get; set; }

    [JsonProperty("Policy")]
    public string Policy { get; set; }

    [JsonProperty("X-Amz-Signature")]
    public string XAmzSignature { get; set; }
  }
}
