using System.Collections.Generic;
using Newtonsoft.Json;
using СloudСonvert.API.Models.Enums;

namespace СloudСonvert.API.Models.TaskOperations
{
  public class TaskCaptureData : BaseOperation
  {
    /// <summary>
    /// URL of the website
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("output_format")]
    public string Output_Format { get; set; }

    [JsonProperty("engine", NullValueHandling = NullValueHandling.Ignore)]
    public string Engine { get; set; }

    [JsonProperty("engine_version", NullValueHandling = NullValueHandling.Ignore)]
    public string Engine_Version { get; set; }

    /// <summary>
    /// Choose a filename(including extension) for the output file.
    /// </summary>
    [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
    public string Filename { get; set; }

    [JsonProperty("pages", NullValueHandling = NullValueHandling.Ignore)]
    public string Pages { get; set; }

    [JsonProperty("zoom", NullValueHandling = NullValueHandling.Ignore)]
    public int? Zoom { get; set; }

    [JsonProperty("page_width", NullValueHandling = NullValueHandling.Ignore)]
    public int? Page_Width { get; set; }


    [JsonProperty("page_height", NullValueHandling = NullValueHandling.Ignore)]
    public int? Page_Height { get; set; }

    [JsonProperty("margin_top", NullValueHandling = NullValueHandling.Ignore)]
    public int? Margin_Top { get; set; }

    [JsonProperty("margin_bottom", NullValueHandling = NullValueHandling.Ignore)]
    public int? Margin_Bottom { get; set; }

    [JsonProperty("margin_left", NullValueHandling = NullValueHandling.Ignore)]
    public int? Margin_Left { get; set; }

    [JsonProperty("margin_right", NullValueHandling = NullValueHandling.Ignore)]
    public int? Margin_Right { get; set; }

    [JsonProperty("print_background", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Print_Background { get; set; }

    [JsonProperty("display_header_footer", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Display_Header_Footer { get; set; }

    [JsonProperty("header_template", NullValueHandling = NullValueHandling.Ignore)]
    public string Header_Template { get; set; }

    [JsonProperty("footer_template", NullValueHandling = NullValueHandling.Ignore)]
    public string Footer_Template { get; set; }

    [JsonProperty("wait_until", NullValueHandling = NullValueHandling.Ignore)]
    public WaitUntil? Wait_Until { get; set; }

    [JsonProperty("wait_for_element", NullValueHandling = NullValueHandling.Ignore)]
    public string Wait_For_Element { get; set; }

    [JsonProperty("wait_time", NullValueHandling = NullValueHandling.Ignore)]
    public int? Wait_Time { get; set; }

    [JsonProperty("headers", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string, string> Headers { get; set; }

    /// <summary>
    /// Timeout in seconds after the task will be cancelled.
    /// </summary>
    [JsonProperty("timeout", NullValueHandling = NullValueHandling.Ignore)]
    public int? Timeout { get; set; }
  }
}
