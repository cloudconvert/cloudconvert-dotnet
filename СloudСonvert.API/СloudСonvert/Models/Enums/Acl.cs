using System.ComponentModel;

namespace СloudСonvert.API.СloudСonvert.Models.Enums
{
  public enum Acl
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
