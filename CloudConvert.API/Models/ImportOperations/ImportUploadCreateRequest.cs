using System.Text.Json.Serialization;

namespace CloudConvert.API.Models.ImportOperations
{
  public class ImportUploadCreateRequest
  {
    [JsonPropertyName("operation")]
    public string Operation { get; } = "import/upload";

    /// <summary>
    /// Redirect user to this URL after upload
    /// </summary>
    [JsonPropertyName("redirect")]
    public string Redirect { get; set; }
  }
}
