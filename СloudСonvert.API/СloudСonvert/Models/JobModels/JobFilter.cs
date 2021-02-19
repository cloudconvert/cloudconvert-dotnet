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
    
    public JobStatus? Status { get; set; }
    public string Tag { get; set; } 
    public string Include { get; set; } 
    public int? PerPage { get; set; }
    public int? Page { get; set; }
  }
}
