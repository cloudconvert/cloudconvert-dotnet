using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CloudConvert.API.Models.Enums;

namespace CloudConvert.API.Models.ExportOperations
{
  public class ExportS3CreateRequest
  {
    [JsonProperty("operation")]
    public static string Operation = "export/s3";

    /// <summary>
    /// The input task name(s) for this task.
    /// input: string | string[];
    /// </summary>
    [JsonProperty("input")]
    public dynamic Input { get; set; }

    /// <summary>
    /// The Amazon S3 bucket where to store the file(s).
    /// </summary>
    [JsonProperty("bucket")]
    public string Bucket { get; set; }

    /// <summary>
    /// Specify the Amazon S3 endpoint, e.g. us-west-2 or eu-west-1.
    /// </summary>
    [JsonProperty("region")]
    public string Region { get; set; }

    [JsonProperty("endpoint", NullValueHandling = NullValueHandling.Ignore)]
    public string Endpoint { get; set; }

    /// <summary>
    /// S3 key for storing the file (the filename in the bucket, including path).
    /// </summary>
    [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
    public string Key { get; set; }

    /// <summary>
    /// Alternatively to using key, you can specify a key prefix for exporting files.
    /// </summary>
    [JsonProperty("key_prefix", NullValueHandling = NullValueHandling.Ignore)]
    public string Key_Prefix { get; set; }

    /// <summary>
    /// The Amazon S3 access key id.
    /// </summary>
    [JsonProperty("access_key_id")]
    public string Access_Key_Id { get; set; }

    /// <summary>
    /// The Amazon S3 secret access key.
    /// </summary>
    [JsonProperty("secret_access_key")]
    public string Secret_Access_Key { get; set; }

    /// <summary>
    /// Auth using temporary credentials.
    /// </summary>
    [JsonProperty("session_token", NullValueHandling = NullValueHandling.Ignore)]
    public string Session_Token { get; set; }

    /// <summary>
    /// S3 ACL for storing the files.
    /// </summary>
    [JsonProperty("acl", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ExportS3Acl? Acl { get; set; }

    /// <summary>
    /// S3 CacheControl header to specify the lifetime of the file.
    /// </summary>
    [JsonProperty("cache_control", NullValueHandling = NullValueHandling.Ignore)]
    public string Cache_Control { get; set; }

    /// <summary>
    /// Object of additional S3 meta data.
    /// </summary>
    [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string, string> Metadata { get; set; }

    /// <summary>
    /// Enable the Server-side encryption algorithm used when storing this object in S3.
    /// </summary>
    [JsonProperty("server_side_encryption", NullValueHandling = NullValueHandling.Ignore)]
    public string Server_Side_Encryption { get; set; }
  }
}
