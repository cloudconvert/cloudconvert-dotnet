using Newtonsoft.Json;

namespace СloudСonvert.API.СloudСonvert.Models.TaskModels
{
  public partial class Payload
  {
    [JsonProperty("input_format")]
    public string Input_Format { get; set; }

    [JsonProperty("output_format")]
    public string Output_Format { get; set; }

    [JsonProperty("page_range")]
    public string Page_Range { get; set; }

    [JsonProperty("optimize_print")]
    public bool Optimize_Print { get; set; }
  }
}
