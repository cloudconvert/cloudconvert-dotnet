using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using Refit;
using СloudСonvert.API;
using СloudСonvert.API.СloudСonvert;
using СloudСonvert.API.СloudСonvert.Models;
using СloudСonvert.API.СloudСonvert.Models.JobModels;
using СloudСonvert.API.СloudСonvert.Models.TaskModels;

namespace СloudСonvert.Test
{
  public class TestJobs
  {
    const string urlApi = "https://api.cloudconvert.com/v2";
    const string apiKey = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIxIiwianRpIjoiNzhlMTU1OTU2ZjQyNjU2YmU4NGJhOGExOTNiZTZkMTdlODA4MWM5MDQ5Yjk4ZDllYjIzMjFkNzgxYTNkOGNkNWYwODQ4NDFiYzRmODczOWQiLCJpYXQiOiIxNjEzNzM5NjIzLjA3NzQ1MSIsIm5iZiI6IjE2MTM3Mzk2MjMuMDc3NDU0IiwiZXhwIjoiNDc2OTQxMzIyMy4wMjA1ODUiLCJzdWIiOiIyMzAwNjM4OSIsInNjb3BlcyI6WyJ1c2VyLndyaXRlIiwidXNlci5yZWFkIiwidGFzay5yZWFkIiwidGFzay53cml0ZSIsIndlYmhvb2sucmVhZCIsIndlYmhvb2sud3JpdGUiLCJwcmVzZXQucmVhZCIsInByZXNldC53cml0ZSJdfQ.mt0E24JFoSSPPtZsham6fMzvz-cCUM_8vp5NEiq3NEvhn8SsHLBBEqug310hK63gIISEuBOqBlC0Nhc41dfsuxzQqu7cSJ86nCeTZc9IgqmgSCk2IzAnSeQeAO409f_qyKTgLeglgYUefRgfuMhDHym9fQLqbMhdYB0cyJufZZ4UoqZewwgUlMl5f4sm-mwKpIiNdIIfXVRyN4Rc1dMSfM3ZXw10YRlvBuIgEQDndnATpl3CuTy2bgw-_TjiAaPgqv2OoYWo5VCOqz3c0L4P9KulfP74mrE2FX2OY4uH9njkUFxfvBlOXIS4F-netI0gI-U4G1N68g9NKYm5mpTIg8dS7iVeOzh0bgFIGuiG56quxiIbKLG5kn8HoT3RsNCIZmHR7azPPXxekxVyqA_LTRRHWwGDXIMPEyWIAfp3GtfU-3Bn8S4imbZUpyMAWUZpDj26itJVQvFYmDM_5dhCQEZoa6eQm3g0_sFSVETAwJl1DxR8yB5HgWgQUmH82Hpn4Nq02xLZ0leyoFYP3bXFsKmtYyDsxYM-S_TkB9bCszdVmO4O753P62nl87zwEU4L0XHhwDb6tdswCBO7uUM_BoUlelmGKNS0Ew-KtOHKQpmrOZgrYWeNGMfMluf4429MlWlNhO8ceYBLakxqo5hh4cF8kbtyCwu9T6nyAJh9aFQ";

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
        var error = JsonConvert.DeserializeObject<ErrorResponse>(ex.Content);
      }
      catch (Exception ex)
      {
      }
    }

    [Test]
    public async Task CreateJob()
    {
      CloudConvertAPI ccAPI = new CloudConvertAPI(urlApi, apiKey);

      var req = new JobCreateRequest
      {
        Tasks = new
        {
          import = new ImportUpload()
        },
        Tag = "Test"
      };

      var result = await ccAPI.CreateJobAsync(req);
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

    [Test]
    public async Task DeleteJob()
    {
      CloudConvertAPI ccAPI = new CloudConvertAPI(urlApi, apiKey);

      await ccAPI.DeleteJobAsync("2d1224e3-aeb1-4b90-8639-d422b6a0b61a");
    }

  }
}
