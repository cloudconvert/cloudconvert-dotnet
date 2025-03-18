using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CloudConvert.API.Models.TaskModels;

namespace CloudConvert.API.Models.JobModels
{
  public partial class JobResponse
  {
    /// <summary>
    /// The ID of the job.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// Your given tag of the job.
    /// </summary>
    [JsonPropertyName("tag")]
    public string Tag { get; set; }

    /// <summary>
    /// The status of the job. Is one of processing, finished or error.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }

    /// <summary>
    /// ISO8601 timestamp of the creation of the job.
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTimeOffset? Created_At { get; set; }

    /// <summary>
    /// ISO8601 timestamp when the job started processing.
    /// </summary>
    [JsonPropertyName("started_at")]
    public DateTimeOffset? Started_At { get; set; }

    /// <summary>
    /// ISO8601 timestamp when the job finished or failed.
    /// </summary>
    [JsonPropertyName("ended_at")]
    public DateTimeOffset? Ended_At { get; set; }

    /// <summary>
    /// List of tasks that are part of the job. You can find details about the task model response in the documentation about the show tasks endpoint.
    /// </summary>
    [JsonPropertyName("tasks")]
    public List<TaskResponse> Tasks { get; set; }

    [JsonPropertyName("links")]
    public ResponseLinks Links { get; set; }
  }
}
