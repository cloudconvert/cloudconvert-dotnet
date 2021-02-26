using System;
using Newtonsoft.Json;

namespace CloudConvert.API.Models
{
  public partial class DatumLinks
  {
    [JsonProperty("self")]
    public Uri Self { get; set; }
  }
}
