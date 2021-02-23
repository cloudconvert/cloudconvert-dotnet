using System.ComponentModel;

namespace СloudСonvert.API.Models.Enums
{
  public enum ExportOperation
  {
    [Description("export/url")]
    ExportUrl,

    [Description("export/s3")]
    ExportS3,

    [Description("export/azure/blob")]
    ExportAzureBlob,

    [Description("export/google-cloud-storage")]
    ExportGoogleCloudStorage,

    [Description("export/openstack")]
    ExportOpenstack,

    [Description("export/sftp")]
    ExportSftp
  }
}
