using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace СloudСonvert.API.СloudСonvert.Models.JobModels
{
  public partial class Job
  {
    [JsonProperty("id")]
    public Guid Id { get; set; }

    [JsonProperty("tag")]
    public string Tag { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("created_at")]
    public DateTimeOffset Created_At { get; set; }

    [JsonProperty("started_at")]
    public DateTimeOffset Started_At { get; set; }

    [JsonProperty("tasks")]
    public List<TaskCC> Tasks { get; set; }

    [JsonProperty("links")]
    public DatumLinks Links { get; set; }
  }
}
