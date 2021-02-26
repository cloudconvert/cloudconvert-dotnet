using System.IO;
using NUnit.Framework;
using CloudConvert.API;

namespace CloudConvert.Test
{
  public class TestWebhook
  {
    const string apiKey = "";
    readonly ICloudConvertAPI _cloudConvertAPI = new CloudConvertAPI(apiKey, true);

    [Test]
    public void Verify()
    {
      var path = @"TestFiles\webhook_job_created_payload.json";
      using (StreamReader r = new StreamReader(path))
      {
        string json = r.ReadToEnd();

        var result = _cloudConvertAPI.ValidateWebhookSignatures(json, "88c3103f1d64282bf963af5dd8405ef26348af25b8903e10f0c288c11f0f907b", "your secret key");

        Assert.IsTrue(result);
      }
      
    }
  }
}
