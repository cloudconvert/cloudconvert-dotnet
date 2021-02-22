using System;
using System.Collections.Generic;
using System.Text;
using СloudСonvert.API.СloudСonvert.Models.Enums;

namespace СloudСonvert.API.СloudСonvert.Models.JobModels
{
  public class JobFilter
  {
    public JobFilter()
    {
      Status = null;
      Tag = null;
      Include = null;
      PerPage = null;
      Page = null;
    }

    /// <summary>
    /// The result will be filtered to include only jobs with a specific status (processing, finished or error).
    /// </summary>
    public JobCCStatus? Status { get; set; }

    /// <summary>
    /// The result will be filtered to include only jobs with a tag.
    /// </summary>
    public string Tag { get; set; }

    /// <summary>
    /// Include tasks in the result.
    /// </summary>
    public string Include { get; set; }

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
