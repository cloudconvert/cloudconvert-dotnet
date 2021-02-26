using Newtonsoft.Json;

namespace CloudConvert.API.Models.ImportOperations
{
  public class ImportUploadData
  {
    [JsonProperty("operation")]
    public static string Operation = "import/upload";

    /// <summary>
    /// Redirect user to this URL after upload
    /// </summary>
    [JsonProperty("redirect", NullValueHandling = NullValueHandling.Ignore)]
    public string Redirect { get; set; }
  }
}
