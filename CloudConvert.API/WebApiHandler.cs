using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CloudConvert.API.Extensions;

namespace CloudConvert.API
{
  internal sealed class WebApiHandler : HttpClientHandler
  {

    private readonly bool _loggingEnabled;

    public WebApiHandler(bool loggingEnabled)
    {
      _loggingEnabled = loggingEnabled;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {

      bool writeLog = _loggingEnabled;

      try
      {
        if (writeLog)
        {
          var requestString = request.Content != null ? await request.Content.ReadAsStringAsync(cancellationToken) : string.Empty;
        }

        var response = await base.SendAsync(request, cancellationToken);

        if (writeLog)
        {
          string responseString = (await response.Content.ReadAsStringAsync(cancellationToken)).TrimLengthWithEllipsis(20000);
        }

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
