using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using CloudConvert.API.Models.Enums;

namespace CloudConvert.API.Models.TaskOperations
{
  public class ThumbnailCreateRequest
  {
    [JsonProperty("operation")]
    public static string Operation = "thumbnail";

    /// <summary>
    /// The input task name(s) for this task.
    /// input: string | string[];
    /// </summary>
    [JsonProperty("input")]
    public dynamic Input { get; set; }

    /// <summary>
    /// If not set, the extension of the input file is used as input format
    /// </summary>
    [JsonProperty("input_format", NullValueHandling = NullValueHandling.Ignore)]
    public string Input_Format { get; set; }

    [JsonProperty("output_format")]
    [JsonConverter(typeof(StringEnumConverter))]
    public ThumbnailOutputFormat Output_Format { get; set; }

    [JsonProperty("engine", NullValueHandling = NullValueHandling.Ignore)]
    public string Engine { get; set; }

    [JsonProperty("engine_version", NullValueHandling = NullValueHandling.Ignore)]
    public string Engine_Version { get; set; }

    /// <summary>
    /// Choose a filename (including extension) for the output file.
    /// </summary>
    [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
    public string Filename { get; set; }

    /// <summary>
    /// Timeout in seconds after the task will be cancelled.
    /// </summary>
    [JsonProperty("timeout", NullValueHandling = NullValueHandling.Ignore)]
    public int? Timeout { get; set; }

    /// <summary>
    /// Sets the mode of sizing the thumbnail. "Max" resizes the thumbnail to fit within the width and height, but will not increase the size of the image if it is smaller than width or height. "Crop" resizes the thumbnail to fill the width and height dimensions and crops any excess image data. "Scale" enforces the thumbnail width and height by scaling. Defaults to max. 
    /// </summary>
    [JsonProperty("fit", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ThumbnailFit? Fit { get; set; }

    /// <summary>
    /// Set thumbnail width in pixels.
    /// </summary>
    [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
    public int? Width { get; set; }

    /// <summary>
    /// Set thumbnail height in pixels.
    /// </summary>
    [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
    public int? Height { get; set; }

    /// <summary>
    /// Number of thumbnails to create. Defaults to 1.
    /// </summary>
    [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
    public int? Count { get; set; }

    /// <summary>
    /// Conversion and engine specific options. Depends on input_format and output_format.
    /// Select input and output format above to show additional conversion options.
    /// </summary>
    [JsonExtensionData]
    [JsonProperty("options", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string, object> Options { get; set; }

  }
}
