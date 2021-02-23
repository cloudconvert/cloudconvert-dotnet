using System;
using Newtonsoft.Json;

namespace СloudСonvert.API.Models.TaskModels
{
  public partial class File
  {
    [JsonProperty("filename")]
    public string Filename { get; set; }

    [JsonProperty("url")]
    public Uri Url { get; set; }
  }
}
