using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace CloudConvert.API
{
  public class RestHelper
  {
    private readonly HttpClient _httpClient;

    internal RestHelper(TimeSpan? httpClientTimeout = null)
    {
      _httpClient = new HttpClient(new WebApiHandler(true));
      
      if (httpClientTimeout != null)
      {
        _httpClient.Timeout = httpClientTimeout.Value;
      }
    }

    public async Task<T> RequestAsync<T>(HttpRequestMessage request)
    {
      var response = await _httpClient.SendAsync(request);

      var responseRaw = await response.Content.ReadAsStringAsync();

      return JsonConvert.DeserializeObject<T>(responseRaw);
    }

    public async Task<string> RequestAsync(HttpRequestMessage request)
    {
      var response = await _httpClient.SendAsync(request);

      return await response.Content.ReadAsStringAsync();
    }
  }
}
