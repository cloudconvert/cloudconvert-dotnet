using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace СloudСonvert.API.СloudСonvert.Models.JobModels
{
  public partial class Result
  {
    [JsonProperty("files")]
    public List<FileCC> Files { get; set; }
  }
}
