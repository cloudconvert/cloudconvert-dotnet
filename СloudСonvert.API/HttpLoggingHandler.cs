using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace СloudСonvert.API
{
  public class HttpLoggingHandler : DelegatingHandler
  {
    public HttpLoggingHandler(HttpMessageHandler innerHandler = null) : base(
        innerHandler ?? new HttpClientHandler())
    {
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
      await Task.Delay(1, cancellationToken).ConfigureAwait(false);
      var start = DateTime.Now;
      var req = request;
      var msg = $"[{req.RequestUri.PathAndQuery} -  Request]";

      Console.WriteLine($"{msg}========Request Start==========");
      Console.WriteLine($"{msg} {req.Method} {req.RequestUri.PathAndQuery} {req.RequestUri.Scheme}/{req.Version}");
      Console.WriteLine($"{msg} Host: {req.RequestUri.Scheme}://{req.RequestUri.Host}");

      foreach (var header in req.Headers)
      {
        Console.WriteLine($"{msg} {header.Key}: {string.Join(", ", header.Value)}");
      }

      if (req.Content != null)
      {
        foreach (var header in req.Content.Headers)
        {
          Console.WriteLine($"{msg} {header.Key}: {string.Join(", ", header.Value)}");
        }

        Console.WriteLine($"{msg} Content:");

        if (req.Content is StringContent || IsTextBasedContentType(req.Headers) || IsTextBasedContentType(req.Content.Headers))
        {
          var result = await req.Content.ReadAsStringAsync();

          Console.WriteLine($"{msg} {string.Join("", result.Cast<char>().Take(4096))}");
        }
      }

      var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

      Console.WriteLine($"{msg}==========Request End==========");

      msg = $"[{req.RequestUri.PathAndQuery} - Response]";

      Console.WriteLine($"{msg}=========Response Start=========");

      var resp = response;

      Console.WriteLine($"{msg} {req.RequestUri.Scheme.ToUpper()}/{resp.Version} {(int)resp.StatusCode} {resp.ReasonPhrase}");

      foreach (var header in resp.Headers)
      {
        Console.WriteLine($"{msg} {header.Key}: {string.Join(", ", header.Value)}");
      }

      if (resp.Content != null)
      {
        foreach (var header in resp.Content.Headers)
        {
          Console.WriteLine($"{msg} {header.Key}: {string.Join(", ", header.Value)}");
        }

        Console.WriteLine($"{msg} Content:");

        if (resp.Content is StringContent || IsTextBasedContentType(resp.Headers) || IsTextBasedContentType(resp.Content.Headers))
        {
          var result = await resp.Content.ReadAsStringAsync();

          Console.WriteLine($"{msg} {string.Join("", result.Cast<char>().Take(4096))}");
        }
      }

      Console.WriteLine($"{msg} Duration: {DateTime.Now - start}");
      Console.WriteLine($"{msg}==========Response End==========");
      return response;
    }

    readonly string[] types = { "html", "text", "xml", "json", "txt", "x-www-form-urlencoded" };

    private bool IsTextBasedContentType(HttpHeaders headers)
    {
      IEnumerable<string> values;
      if (!headers.TryGetValues("Content-Type", out values))
        return false;
      var header = string.Join(" ", values).ToLowerInvariant();

      return types.Any(t => header.Contains(t));
    }
  }
}
