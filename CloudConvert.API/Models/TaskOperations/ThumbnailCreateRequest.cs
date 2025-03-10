using System.Collections.Generic;
using System.Text.Json.Serialization;
using CloudConvert.API.Models.Enums;

namespace CloudConvert.API.Models.TaskOperations
{
  public class ThumbnailCreateRequest
  {
    [JsonPropertyName("operation")]
    public string Operation { get; } = "thumbnail";

    /// <summary>
    /// The input task name(s) for this task.
    /// input: string | string[];
    /// </summary>
    [JsonPropertyName("input")]
    public object Input { get; set; }

    /// <summary>
    /// If not set, the extension of the input file is used as input format
    /// </summary>
    [JsonPropertyName("input_format")]
    public string Input_Format { get; set; }

    [JsonPropertyName("output_format")]
    public ThumbnailOutputFormat Output_Format { get; set; }

    [JsonPropertyName("engine")]
    public string Engine { get; set; }

    [JsonPropertyName("engine_version")]
    public string Engine_Version { get; set; }

    /// <summary>
    /// Choose a filename (including extension) for the output file.
    /// </summary>
    [JsonPropertyName("filename")]
    public string Filename { get; set; }

    /// <summary>
    /// Timeout in seconds after the task will be cancelled.
    /// </summary>
    [JsonPropertyName("timeout")]
    public int? Timeout { get; set; }

    /// <summary>
    /// Sets the mode of sizing the thumbnail. "Max" resizes the thumbnail to fit within the width and height, but will not increase the size of the image if it is smaller than width or height. "Crop" resizes the thumbnail to fill the width and height dimensions and crops any excess image data. "Scale" enforces the thumbnail width and height by scaling. Defaults to max. 
    /// </summary>
    [JsonPropertyName("fit")]
    public ThumbnailFit? Fit { get; set; }

    /// <summary>
    /// Set thumbnail width in pixels.
    /// </summary>
    [JsonPropertyName("width")]
    public int? Width { get; set; }

    /// <summary>
    /// Set thumbnail height in pixels.
    /// </summary>
    [JsonPropertyName("height")]
    public int? Height { get; set; }

    /// <summary>
    /// Number of thumbnails to create. Defaults to 1.
    /// </summary>
    [JsonPropertyName("count")]
    public int? Count { get; set; }

    /// <summary>
    /// Conversion and engine specific options. Depends on input_format and output_format.
    /// Select input and output format above to show additional conversion options.
    /// </summary>
    [JsonExtensionData]
    [JsonPropertyName("options")]
    public Dictionary<string, object> Options { get; set; }
  }
}
