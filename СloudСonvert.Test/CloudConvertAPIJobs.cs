using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Refit;
using СloudСonvert.API;
using СloudСonvert.API.СloudСonvert;
using СloudСonvert.API.СloudСonvert.Models.JobModels;

namespace СloudСonvert.Test
{
  public class CloudConvertAPIJobs
  {
    const string urlApi = "https://api.cloudconvert.com/v2";
    const string apiKey = "";

    [Test]
    public async Task GetAllJobs()
    {
      CloudConvertAPI ccAPI = new CloudConvertAPI(urlApi, apiKey);
      try
      {
        JobFilter filter = new JobFilter();
        var result = await ccAPI.GetAllJobsAsync(filter);
      }
      catch (WebApiException ex)
      {
      }
      catch (ApiException ex)
      {
      }
      catch (Exception ex)
      {
      }
    }


    [Test]
    public async Task GetJob()
    {
      CloudConvertAPI ccAPI = new CloudConvertAPI(urlApi, apiKey);

      var result = await ccAPI.GetJobAsync("5b5a6eed-1be3-4179-8f3c-8600b6835881");
    }

    [Test]
    public async Task WaitJob()
    {
      CloudConvertAPI ccAPI = new CloudConvertAPI(urlApi, apiKey);

      var result = await ccAPI.WaitJobAsync("5b5a6eed-1be3-4179-8f3c-8600b6835881");
    }

  }
}
