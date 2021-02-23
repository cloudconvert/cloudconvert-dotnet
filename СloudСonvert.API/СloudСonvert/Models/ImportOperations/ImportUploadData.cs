using Newtonsoft.Json;

namespace СloudСonvert.API.СloudСonvert.Models.ImportOperations
{
  public class ImportUploadData : BaseOperation
  {
    /// <summary>
    /// Redirect user to this URL after upload
    /// </summary>
    [JsonProperty("redirect")]
    public string Redirect { get; set; }
  }
}
