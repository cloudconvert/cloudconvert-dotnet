using System.Collections.Generic;
using System.Text.Json.Serialization;
using CloudConvert.API.Models.Enums;

namespace CloudConvert.API.Models.ExportOperations
{
  public class ExportS3CreateRequest
  {
    [JsonPropertyName("operation")]
    public string Operation { get; } = "export/s3";

    /// <summary>
    /// The input task name(s) for this task.
    /// input: string | string[];
    /// </summary>
    [JsonPropertyName("input")]
    public object Input { get; set; }

    /// <summary>
    /// The Amazon S3 bucket where to store the file(s).
    /// </summary>
    [JsonPropertyName("bucket")]
    public string Bucket { get; set; }

    /// <summary>
    /// Specify the Amazon S3 endpoint, e.g. us-west-2 or eu-west-1.
    /// </summary>
    [JsonPropertyName("region")]
    public string Region { get; set; }

    [JsonPropertyName("endpoint")]
    public string Endpoint { get; set; }

    /// <summary>
    /// S3 key for storing the file (the filename in the bucket, including path).
    /// </summary>
    [JsonPropertyName("key")]
    public string Key { get; set; }

    /// <summary>
    /// Alternatively to using key, you can specify a key prefix for exporting files.
    /// </summary>
    [JsonPropertyName("key_prefix")]
    public string Key_Prefix { get; set; }

    /// <summary>
    /// The Amazon S3 access key id.
    /// </summary>
    [JsonPropertyName("access_key_id")]
    public string Access_Key_Id { get; set; }

    /// <summary>
    /// The Amazon S3 secret access key.
    /// </summary>
    [JsonPropertyName("secret_access_key")]
    public string Secret_Access_Key { get; set; }

    /// <summary>
    /// Auth using temporary credentials.
    /// </summary>
    [JsonPropertyName("session_token")]
    public string Session_Token { get; set; }

    /// <summary>
    /// S3 ACL for storing the files.
    /// </summary>
    [JsonPropertyName("acl")]
    public ExportS3Acl? Acl { get; set; }

    /// <summary>
    /// S3 CacheControl header to specify the lifetime of the file.
    /// </summary>
    [JsonPropertyName("cache_control")]
    public string Cache_Control { get; set; }

    /// <summary>
    /// Object of additional S3 meta data.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, string> Metadata { get; set; }

    /// <summary>
    /// Enable the Server-side encryption algorithm used when storing this object in S3.
    /// </summary>
    [JsonPropertyName("server_side_encryption")]
    public string Server_Side_Encryption { get; set; }
  }
}
