using System;
using Newtonsoft.Json;
using СloudСonvert.API.Models.Enums;

namespace СloudСonvert.API.Models.TaskModels
{
  public partial class TaskCC
  {
    /// <summary>
    /// The ID of the task.
    /// </summary>
    [JsonProperty("id")]
    public Guid Id { get; set; }

    /// <summary>
    /// The Job ID the tasks belongs to.
    /// </summary>
    [JsonProperty("job_id")]
    public Guid? Job_Id { get; set; }

    /// <summary>
    /// Name of the operation, for example convert or import/s3.
    /// </summary>
    [JsonProperty("operation")]
    public string Operation { get; set; }

    /// <summary>
    /// The status of the task. Is one of waiting, processing, finished or error.
    /// </summary>
    [JsonProperty("status")]
    public TaskCCStatus Status { get; set; }

    /// <summary>
    /// The amount of conversion minutes the task consumed. Available when the status is finished.
    /// </summary>
    [JsonProperty("credits")]
    public int? Credits { get; set; }

    /// <summary>
    /// The status message. Contains the error message if the task status is error.
    /// </summary>
    [JsonProperty("message")]
    public object Message { get; set; }

    /// <summary>
    /// The error code if the task status is error.
    /// </summary>
    [JsonProperty("code")]
    public string Code { get; set; }

    /// <summary>
    /// ISO8601 timestamp of the creation of the task.
    /// </summary>
    [JsonProperty("created_at")]
    public DateTimeOffset? Created_At { get; set; }

    /// <summary>
    /// ISO8601 timestamp when the task started processing.
    /// </summary>
    [JsonProperty("started_at")]
    public DateTimeOffset? Started_At { get; set; }

    /// <summary>
    /// ISO8601 timestamp when the task finished or failed.
    /// </summary>
    [JsonProperty("ended_at")]
    public DateTimeOffset? Ended_At { get; set; }

    /// <summary>
    /// List of tasks that are dependencies for this task. Only available if the include parameter was set to depends_on_tasks.
    /// </summary>
    [JsonProperty("depends_on_tasks")]
    public object Depends_On_Tasks { get; set; }

    /// <summary>
    /// ID of the original task, if this task is a retry.
    /// </summary>
    [JsonProperty("retry_of_task_id")]
    public string Retry_Of_Task_Id { get; set; }

    /// <summary>
    /// List of tasks that are retries of this task. Only available if the include parameter was set to retries.
    /// </summary>
    [JsonProperty("retries")]
    public string Retries { get; set; }

    /// <summary>
    /// Name of the engine.
    /// </summary>
    [JsonProperty("engine")]
    public string Engine { get; set; }

    /// <summary>
    /// Version of the engine.
    /// </summary>
    [JsonProperty("engine_version")]
    public string Engine_Version { get; set; }

    /// <summary>
    /// Your submitted payload for the tasks. Depends on the operation type.
    /// </summary>
    [JsonProperty("payload")]
    public object Payload { get; set; }

    /// <summary>
    /// The result of the task. Depends on the operation type. 
    /// Finished tasks always do have a files key with the names of the result files of the task (See the example on the right).
    /// </summary>
    [JsonProperty("result")]
    public object Result { get; set; }


    [JsonProperty("links")]
    public DatumLinks Links { get; set; }
  }
}
