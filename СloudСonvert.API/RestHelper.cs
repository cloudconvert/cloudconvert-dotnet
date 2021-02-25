using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace СloudСonvert.API
{
  public class RestHelper
  {
    private readonly HttpClient _httpClient;

    internal RestHelper()
    {
      _httpClient = new HttpClient(new WebApiHandler(true));
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
