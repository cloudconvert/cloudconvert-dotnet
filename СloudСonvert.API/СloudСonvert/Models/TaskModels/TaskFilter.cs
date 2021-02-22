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

    public TaskStatus? Status { get; set; }
    public string JobId { get; set; }
    public string Operation { get; set; }
    public string Include { get; set; }
    public int? PerPage { get; set; }
    public int? Page { get; set; }
  }
}
