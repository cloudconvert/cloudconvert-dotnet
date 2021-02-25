using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using СloudСonvert.API.Models.TaskModels;

namespace СloudСonvert.API.Models.JobModels
{
  public partial class JobCC
  {
    /// <summary>
    /// The ID of the job.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// Your given tag of the job.
    /// </summary>
    [JsonProperty("tag")]
    public string Tag { get; set; }

    /// <summary>
    /// The status of the job. Is one of processing, finished or error.
    /// </summary>
    [JsonProperty("status")]
    public string Status { get; set; }

    /// <summary>
    /// ISO8601 timestamp of the creation of the job.
    /// </summary>
    [JsonProperty("created_at")]
    public DateTimeOffset? Created_At { get; set; }

    /// <summary>
    /// ISO8601 timestamp when the job started processing.
    /// </summary>
    [JsonProperty("started_at")]
    public DateTimeOffset? Started_At { get; set; }

    /// <summary>
    /// ISO8601 timestamp when the job finished or failed.
    /// </summary>
    [JsonProperty("ended_at")]
    public DateTimeOffset? Ended_At { get; set; }

    /// <summary>
    /// List of tasks that are part of the job. You can find details about the task model response in the documentation about the show tasks endpoint.
    /// </summary>
    [JsonProperty("tasks")]
    public List<TaskCC> Tasks { get; set; }

    [JsonProperty("links")]
    public DatumLinks Links { get; set; }
  }
}
