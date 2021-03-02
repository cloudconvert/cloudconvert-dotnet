using System.ComponentModel;

namespace CloudConvert.API.Models.Enums
{
  public enum ExportS3Acl
  {
    [Description("private")]
    Private,

    [Description("public-read")]
    PublicRead,

    [Description("public-read-write")]
    PublicReadWrite,

    [Description("authenticated-read")]
    AuthenticatedRead,

    [Description("bucket-owner-read")]
    BucketOwnerRead,

    [Description("bucket-owner-full-control")]
    BucketOwnerFullControl    
  };

}
