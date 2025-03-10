using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CloudConvert.API.Models.Enums;

namespace CloudConvert.API.Models.TaskModels
{
  public partial class TaskResponse
  {
    /// <summary>
    /// The ID of the task.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// The Job ID the task belongs to.
    /// </summary>
    [JsonPropertyName("job_id")]
    public string Job_Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// Name of the operation, for example convert or import/s3.
    /// </summary>
    [JsonPropertyName("operation")]
    public string Operation { get; set; }

    /// <summary>
    /// The status of the task. Is one of waiting, processing, finished or error.
    /// </summary>
    [JsonPropertyName("status")]
    public TaskStatus Status { get; set; }

    /// <summary>
    /// The amount of conversion minutes the task consumed. Available when the status is finished.
    /// </summary>
    [JsonPropertyName("credits")]
    public int? Credits { get; set; }

    /// <summary>
    /// The status message. Contains the error message if the task status is error.
    /// </summary>
    [JsonPropertyName("message")]
    public object Message { get; set; }

    /// <summary>
    /// The error code if the task status is error.
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("percent")]
    public int Percent { get; set; }

    /// <summary>
    /// ISO8601 timestamp of the creation of the task.
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTimeOffset? Created_At { get; set; }

    /// <summary>
    /// ISO8601 timestamp when the task started processing.
    /// </summary>
    [JsonPropertyName("started_at")]
    public DateTimeOffset? Started_At { get; set; }

    /// <summary>
    /// ISO8601 timestamp when the task finished or failed.
    /// </summary>
    [JsonPropertyName("ended_at")]
    public DateTimeOffset? Ended_At { get; set; }

    /// <summary>
    /// List of tasks that are dependencies for this task. Only available if the include parameter was set to depends_on_tasks.
    /// </summary>
    [JsonPropertyName("depends_on_tasks")]
    public object Depends_On_Tasks { get; set; }

    [JsonPropertyName("depends_on_task_ids")]
    public List<string> Depends_On_Task_Ids { get; set; }

    /// <summary>
    /// ID of the original task, if this task is a retry.
    /// </summary>
    [JsonPropertyName("retry_of_task_id")]
    public string Retry_Of_Task_Id { get; set; }

    [JsonPropertyName("copy_of_task_id")]
    public object Copy_Of_Task_Id { get; set; }

    [JsonPropertyName("user_id")]
    public int User_Id { get; set; }

    [JsonPropertyName("priority")]
    public long Priority { get; set; }

    [JsonPropertyName("host_name")]
    public object Host_Name { get; set; }

    [JsonPropertyName("storage")]
    public string Storage { get; set; }

    /// <summary>
    /// List of tasks that are retries of this task. Only available if the include parameter was set to retries.
    /// </summary>
    [JsonPropertyName("retries")]
    public string Retries { get; set; }

    /// <summary>
    /// Name of the engine.
    /// </summary>
    [JsonPropertyName("engine")]
    public string Engine { get; set; }

    /// <summary>
    /// Version of the engine.
    /// </summary>
    [JsonPropertyName("engine_version")]
    public string Engine_Version { get; set; }

    /// <summary>
    /// Your submitted payload for the tasks. Depends on the operation type.
    /// </summary>
    [JsonPropertyName("payload")]
    public object Payload { get; set; }

    /// <summary>
    /// The result of the task. Depends on the operation type. 
    /// Finished tasks always do have a files key with the names of the result files of the task (See the example on the right).
    /// </summary>
    [JsonPropertyName("result")]
    public TaskResult Result { get; set; }

    [JsonPropertyName("links")]
    public ResponseLinks Links { get; set; }
  }
}
