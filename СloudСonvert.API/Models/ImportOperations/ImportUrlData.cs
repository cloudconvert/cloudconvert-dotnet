using System.Collections.Generic;
using Newtonsoft.Json;

namespace СloudСonvert.API.Models.ImportOperations
{
  public class ImportUrlData : BaseOperation
  {
    [JsonProperty("url")]
    public string Url { get; set; }

    /// <summary>
    /// The filename of the input file, including extension. If none provided we will try to detect the filename from the URL.
    /// </summary>
    [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
    public string Filename { get; set; }

    [JsonProperty("headers", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string, string> Headers { get; set; }

  }
}
