using System.IO;
using CloudConvert.API;
using NUnit.Framework;

namespace CloudConvert.Test
{
  public class TestWebhook
  {
    const string apiKey = "";
    readonly ICloudConvertAPI _cloudConvertAPI = new CloudConvertAPI(apiKey, true);

    [Test]
    public void Verify()
    {
      var path = @"Responses/webhook_job_created_payload.json";
      string json = File.ReadAllText(path);

      var result = _cloudConvertAPI.ValidateWebhookSignatures(json, "88c3103f1d64282bf963af5dd8405ef26348af25b8903e10f0c288c11f0f907b", "9E1I8fQSLM7WsH1Y2Zp0uurYfhLqdERu");

      Assert.IsTrue(result);
    }
  }
}
