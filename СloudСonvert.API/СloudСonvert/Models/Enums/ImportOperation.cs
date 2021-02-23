using System.ComponentModel;

namespace СloudСonvert.API.СloudСonvert.Models.Enums
{
  public enum ImportOperation
  {
    [Description("import/upload")]
    ImportUpload,
    [Description("import/url")]
    ImportUrl,
    [Description("import/s3")]
    ImportS3,
    [Description("import/azure/blob")]
    ImportAzureBlob,
    [Description("import/google-cloud-storage")]
    ImportGoogleCloudStorage,
    [Description("import/openstack")]
    ImportOpenstack,
    [Description("import/sftp")]
    ImportSftp
  }
}
