using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CloudConvert.API
{
  public class RestHelper
  {
    private readonly HttpClient _httpClient;

    internal RestHelper()
    {
      _httpClient = new HttpClient(new WebApiHandler());
      _httpClient.Timeout = System.TimeSpan.FromMilliseconds(System.Threading.Timeout.Infinite);
    }

    internal RestHelper(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    internal async Task<T> RequestAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken)
    {
      var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

      // Short-circuit earlier as 204 will never have a body to read
      if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
      {
        return default;
      }

      var responseRaw = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

      if (string.IsNullOrWhiteSpace(responseRaw))
      {
        return default;
      }

      return JsonSerializer.Deserialize<T>(responseRaw, DefaultJsonSerializerOptions.SerializerOptions);
    }

    internal async Task<string> RequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
      var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
      return await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
    }
  }
}
