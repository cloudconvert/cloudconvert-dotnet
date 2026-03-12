namespace CloudConvert.API.Extensions;

/// <summary>
/// Configuration options for the CloudConvert API client.
/// </summary>
public class CloudConvertOptions
{
  /// <summary>
  /// The CloudConvert API key used to authenticate requests.
  /// </summary>
  public string ApiKey { get; set; }

  /// <summary>
  /// Whether to use the CloudConvert sandbox environment.
  /// Use <c>true</c> during development and testing to avoid consuming real credits.
  /// Defaults to <c>false</c>.
  /// </summary>
  public bool IsSandbox { get; set; } = false;
}
