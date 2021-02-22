using System;
using Newtonsoft.Json;

namespace СloudСonvert.API.СloudСonvert.Models
{
  public partial class DatumLinks
  {
    [JsonProperty("self")]
    public Uri Self { get; set; }
  }
}
