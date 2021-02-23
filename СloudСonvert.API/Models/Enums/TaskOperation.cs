using System.ComponentModel;

namespace СloudСonvert.API.Models.Enums
{
  public enum TaskOperation
  {
    [Description("convert")]
    Convert,

    [Description("capture-website")]
    CaptureWebsite,

    [Description("optimize")]
    Optimize,

    [Description("thumbnail")]
    Thumbnail,

    [Description("metadata")]
    Metadata,

    [Description("merge")]
    Merge,

    [Description("archive")]
    Archive,

    [Description("command")]
    Command
  }
}
