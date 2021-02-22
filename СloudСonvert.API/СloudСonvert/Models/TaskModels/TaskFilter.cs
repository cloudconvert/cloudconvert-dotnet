using СloudСonvert.API.СloudСonvert.Models.Enums;

namespace СloudСonvert.API.СloudСonvert.Models.TaskModels
{
  public class TaskFilter
  {
    public TaskFilter()
    {
      Status = null;
      JobId = null;
      Operation = null;
      Include = null;
      PerPage = null;
      Page = null;
    }

    /// <summary>
    /// The result will be filtered to include only tasks with a specific status (waiting, processing, finished or error).
    /// </summary>
    public TaskCCStatus? Status { get; set; }

    /// <summary>
    /// The result will be filtered to include only tasks for a specific Job ID.
    /// </summary>
    public string JobId { get; set; }

    /// <summary>
    /// Filter result to only include tasks of with a matching operation (for example convert or import/s3).
    /// </summary>
    public string Operation { get; set; }

    /// <summary>
    /// Include retries, depends_on_tasks, payload and/or job in the result. Multiple include values are separated by ,.
    /// </summary>
    public string[] Include { get; set; }

    /// <summary>
    /// Number of tasks per page, defaults to 100.
    /// </summary>
    public int? PerPage { get; set; }

    /// <summary>
    /// The result page to show.
    /// </summary>
    public int? Page { get; set; }
  }
}
