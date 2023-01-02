using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Language.Flow;
using Moq.Protected;

namespace CloudConvert.Test.Extensions
{
  public static class MockExtensions
  {
    public static IReturnsResult<HttpMessageHandler> MockResponse(this Mock<HttpMessageHandler> mock, string endpoint, string fileName)
    {
      return mock.Protected()
        .Setup<Task<HttpResponseMessage>>("SendAsync",
          ItExpr.Is<HttpRequestMessage>(message => message.RequestUri.AbsolutePath.EndsWith(endpoint)),
          ItExpr.IsAny<CancellationToken>())
        .ReturnsAsync(new HttpResponseMessage
        {
          StatusCode = HttpStatusCode.OK,
          Content = new StringContent(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Responses", fileName)))
        });
    }

    public static void VerifyRequest(this Mock<HttpMessageHandler> mock, string endpoint, Times times)
    {
      mock.Protected()
        .Verify("SendAsync",
          times,
          ItExpr.Is<HttpRequestMessage>(message => message.RequestUri.AbsolutePath.EndsWith(endpoint)),
          ItExpr.IsAny<CancellationToken>());
    }
  }
}
