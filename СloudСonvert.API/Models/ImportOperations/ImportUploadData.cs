using Newtonsoft.Json;

namespace СloudСonvert.API.Models.ImportOperations
{
  public class ImportUploadData : BaseOperation
  {
    /// <summary>
    /// Redirect user to this URL after upload
    /// </summary>
    [JsonProperty("redirect", NullValueHandling = NullValueHandling.Ignore)]
    public string Redirect { get; set; }
  }
}
