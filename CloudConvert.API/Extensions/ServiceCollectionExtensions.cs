using System;
using System.Net.Http;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

namespace CloudConvert.API.Extensions;

/// <summary>
/// Extension methods for registering CloudConvert API services with the dependency injection container.
/// </summary>
public static class ServiceCollectionExtensions
{
  /// <summary>
  /// Registers the CloudConvert API client and its dependencies with the dependency injection container.
  /// </summary>
  /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
  /// <param name="configure">A delegate to configure the <see cref="CloudConvertOptions"/>.</param>
  /// <returns>The <see cref="IServiceCollection"/> so that calls can be chained.</returns>
  /// <exception cref="ArgumentException">Thrown when <see cref="CloudConvertOptions.ApiKey"/> is not provided.</exception>
  /// <remarks>
  /// Register the CloudConvert API client in your DI container:
  /// <code>
  /// services.AddCloudConvertAPI(options =>
  /// {
  ///     options.ApiKey = "your_api_key";
  ///     options.IsSandbox = false;
  /// });
  /// </code>
  /// </remarks>
  public static IServiceCollection AddCloudConvertAPI(
    this IServiceCollection services,
    Action<CloudConvertOptions> configure)
  {
    var options = new CloudConvertOptions();
    configure(options);

    if (string.IsNullOrWhiteSpace(options.ApiKey))
    {
      throw new ArgumentException("ApiKey is required", nameof(configure));
    }

    services.AddHttpClient<ICloudConvertAPI, CloudConvertAPI>(client =>
    {
      client.Timeout = Timeout.InfiniteTimeSpan;
    })
    .ConfigurePrimaryHttpMessageHandler(() => new WebApiHandler(false));

    services.AddSingleton<ICloudConvertAPI>(sp =>
    {
      var httpClient = sp.GetRequiredService<IHttpClientFactory>()
          .CreateClient(nameof(CloudConvertAPI));

      return new CloudConvertAPI(new RestHelper(httpClient), options.ApiKey, options.IsSandbox);
    });

    return services;
  }
}
