using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CloudConvert.API.Extensions;

namespace CloudConvert.API
{
  internal sealed class WebApiHandler() : HttpClientHandler
  {
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
      try
      {
        var response = await base.SendAsync(request, cancellationToken);

        if ((int)response.StatusCode >= 400)
        {
          throw new WebApiException((await response.Content.ReadAsStringAsync(cancellationToken)).TrimLengthWithEllipsis(20000));
        }

        return response;
      }
      catch (Exception exc)
      {
        throw new WebApiException($"{request.Method} {request.RequestUri} failed: {exc.Message}", exc);
      }
    }
  }
}
