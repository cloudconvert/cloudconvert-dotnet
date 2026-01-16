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
      _httpClient = new HttpClient(new WebApiHandler(true));
      _httpClient.Timeout = System.TimeSpan.FromMilliseconds(System.Threading.Timeout.Infinite);
    }

    internal RestHelper(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<T> RequestAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken)
    {
      var response = await _httpClient.SendAsync(request, cancellationToken);
      var responseRaw = await response.Content.ReadAsStringAsync(cancellationToken);

      // Handle empty response body (e.g., HTTP 204 No Content)
      // System.Text.Json throws when trying to deserialize an empty string
      if (string.IsNullOrWhiteSpace(responseRaw) || response.StatusCode == System.Net.HttpStatusCode.NoContent)
      {
        return default(T);
      }

      return JsonSerializer.Deserialize<T>(responseRaw, DefaultJsonSerializerOptions.SerializerOptions);
    }

    public async Task<string> RequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
      var response = await _httpClient.SendAsync(request, cancellationToken);
      return await response.Content.ReadAsStringAsync(cancellationToken);
    }
  }
}
