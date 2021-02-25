using Newtonsoft.Json;

namespace СloudСonvert.API.Models.ImportOperations
{
  public class ImportS3Data
  {
    [JsonProperty("operation")]
    public static string Operation = "import/s3";

    /// <summary>
    /// The Amazon S3 bucket where to download the file.
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
    /// S3 key of the input file (the filename in the bucket, including path).
    /// </summary>
    [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
    public string Key { get; set; }

    /// <summary>
    /// Alternatively to using key, you can specify a key prefix for importing multiple files.
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

    [JsonProperty("filename")]
    public string Filename { get; set; }
  }
}
