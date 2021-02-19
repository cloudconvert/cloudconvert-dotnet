using System;
using Newtonsoft.Json;

namespace СloudСonvert.API.СloudСonvert.Models.JobModels
{
  public partial class FileCC
  {
    [JsonProperty("filename")]
    public string Filename { get; set; }

    [JsonProperty("url")]
    public Uri Url { get; set; }
  }
}
