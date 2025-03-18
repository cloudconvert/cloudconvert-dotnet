using System.Collections.Generic;
using System.Text.Json.Serialization;
using CloudConvert.API.Models.Enums;

namespace CloudConvert.API.Models.TaskOperations
{
  public class CaptureWebsiteCreateRequest
  {
    [JsonPropertyName("operation")]
    public string Operation { get; } = "capture-website";

    /// <summary>
    /// URL of the website
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("output_format")]
    public string Output_Format { get; set; }

    [JsonPropertyName("engine")]
    public string Engine { get; set; }

    [JsonPropertyName("engine_version")]
    public string Engine_Version { get; set; }

    /// <summary>
    /// Choose a filename(including extension) for the output file.
    /// </summary>
    [JsonPropertyName("filename")]
    public string Filename { get; set; }

    [JsonPropertyName("pages")]
    public string Pages { get; set; }

    [JsonPropertyName("zoom")]
    public int? Zoom { get; set; }

    [JsonPropertyName("page_width")]
    public int? Page_Width { get; set; }

    [JsonPropertyName("page_height")]
    public int? Page_Height { get; set; }

    [JsonPropertyName("margin_top")]
    public int? Margin_Top { get; set; }

    [JsonPropertyName("margin_bottom")]
    public int? Margin_Bottom { get; set; }

    [JsonPropertyName("margin_left")]
    public int? Margin_Left { get; set; }

    [JsonPropertyName("margin_right")]
    public int? Margin_Right { get; set; }

    [JsonPropertyName("print_background")]
    public bool? Print_Background { get; set; }

    [JsonPropertyName("display_header_footer")]
    public bool? Display_Header_Footer { get; set; }

    [JsonPropertyName("header_template")]
    public string Header_Template { get; set; }

    [JsonPropertyName("footer_template")]
    public string Footer_Template { get; set; }

    [JsonPropertyName("wait_until")]
    public CaptureWebsiteWaitUntil? Wait_Until { get; set; }

    [JsonPropertyName("wait_for_element")]
    public string Wait_For_Element { get; set; }

    [JsonPropertyName("wait_time")]
    public int? Wait_Time { get; set; }

    [JsonPropertyName("headers")]
    public Dictionary<string, string> Headers { get; set; }

    /// <summary>
    /// Timeout in seconds after the task will be cancelled.
    /// </summary>
    [JsonPropertyName("timeout")]
    public int? Timeout { get; set; }

    /// <summary>
    /// Conversion and engine-specific options. Depends on input_format and output_format.
    /// Select input and output format above to show additional conversion options.
    /// </summary>
    [JsonExtensionData]
    [JsonPropertyName("options")]
    public Dictionary<string, object> Options { get; set; }
  }
}
