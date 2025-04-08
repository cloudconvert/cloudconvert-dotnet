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

      return JsonSerializer.Deserialize<T>(responseRaw, DefaultJsonSerializerOptions.SerializerOptions);
    }

    public async Task<string> RequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
      var response = await _httpClient.SendAsync(request, cancellationToken);
      return await response.Content.ReadAsStringAsync(cancellationToken);
    }
  }
}
