using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using Refit;
using СloudСonvert.API;
using СloudСonvert.API.Extensions;
using СloudСonvert.API.Models;
using СloudСonvert.API.Models.Enums;
using СloudСonvert.API.Models.TaskModels;
using СloudСonvert.API.Models.TaskOperations;

namespace СloudСonvert.Test
{
  public class TestTasks
  {
    const string apiKey = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIxIiwianRpIjoiNzhlMTU1OTU2ZjQyNjU2YmU4NGJhOGExOTNiZTZkMTdlODA4MWM5MDQ5Yjk4ZDllYjIzMjFkNzgxYTNkOGNkNWYwODQ4NDFiYzRmODczOWQiLCJpYXQiOiIxNjEzNzM5NjIzLjA3NzQ1MSIsIm5iZiI6IjE2MTM3Mzk2MjMuMDc3NDU0IiwiZXhwIjoiNDc2OTQxMzIyMy4wMjA1ODUiLCJzdWIiOiIyMzAwNjM4OSIsInNjb3BlcyI6WyJ1c2VyLndyaXRlIiwidXNlci5yZWFkIiwidGFzay5yZWFkIiwidGFzay53cml0ZSIsIndlYmhvb2sucmVhZCIsIndlYmhvb2sud3JpdGUiLCJwcmVzZXQucmVhZCIsInByZXNldC53cml0ZSJdfQ.mt0E24JFoSSPPtZsham6fMzvz-cCUM_8vp5NEiq3NEvhn8SsHLBBEqug310hK63gIISEuBOqBlC0Nhc41dfsuxzQqu7cSJ86nCeTZc9IgqmgSCk2IzAnSeQeAO409f_qyKTgLeglgYUefRgfuMhDHym9fQLqbMhdYB0cyJufZZ4UoqZewwgUlMl5f4sm-mwKpIiNdIIfXVRyN4Rc1dMSfM3ZXw10YRlvBuIgEQDndnATpl3CuTy2bgw-_TjiAaPgqv2OoYWo5VCOqz3c0L4P9KulfP74mrE2FX2OY4uH9njkUFxfvBlOXIS4F-netI0gI-U4G1N68g9NKYm5mpTIg8dS7iVeOzh0bgFIGuiG56quxiIbKLG5kn8HoT3RsNCIZmHR7azPPXxekxVyqA_LTRRHWwGDXIMPEyWIAfp3GtfU-3Bn8S4imbZUpyMAWUZpDj26itJVQvFYmDM_5dhCQEZoa6eQm3g0_sFSVETAwJl1DxR8yB5HgWgQUmH82Hpn4Nq02xLZ0leyoFYP3bXFsKmtYyDsxYM-S_TkB9bCszdVmO4O753P62nl87zwEU4L0XHhwDb6tdswCBO7uUM_BoUlelmGKNS0Ew-KtOHKQpmrOZgrYWeNGMfMluf4429MlWlNhO8ceYBLakxqo5hh4cF8kbtyCwu9T6nyAJh9aFQ";
    readonly ICloudConvertAPI _cloudConvertAPI = new CloudConvertAPI(apiKey);

    [Test]
    public async Task GetAllTasks()
    {
      try
      {
        TaskFilter filter = new TaskFilter();
        var result = await _cloudConvertAPI.GetAllTasksAsync(filter);
      }
      catch (WebApiException ex)
      {
      }
      catch (ApiException ex)
      {
        if (ex.Content != null)
        {
          var error = JsonConvert.DeserializeObject<ErrorResponse>(ex.Content);
        }
        else
        {
          var error = ex.Message;
        }
      }
      catch (Exception ex)
      {
      }
    }

    [Test]
    public async Task CreateTask()
    {
      var req = new TaskConvertData
      {
        Operation = TaskOperation.Convert.GetEnumDescription(),
        Input = "941a21d2-0d13-4c83-94de-7fe760e16fc4", //Guid import
        Input_Format = "pdf",
        Output_Format = "docx",
        Page_Range = "1-2",
        Optimize_Print = true,
        Engine = "bcl"
      };

      var result = await _cloudConvertAPI.CreateTaskAsync(TaskOperation.Convert.GetEnumDescription(), req);
    }

    [Test]
    public async Task GetTask()
    {
      var result = await _cloudConvertAPI.GetTaskAsync("db14fa95-9cf3-482c-92d1-34c26551bba0");
    }

    [Test]
    public async Task WaitTask()
    {
      var result = await _cloudConvertAPI.WaitTaskAsync("c8a8da46-3758-45bf-b983-2510e3170acb");
    }

    [Test]
    public async Task DeleteTask()
    {
      await _cloudConvertAPI.DeleteTaskAsync("c8a8da46-3758-45bf-b983-2510e3170acb");
    }

    //[Test]
    //public async Task Upload()
    //{
    //  CloudConvertAPI ccAPI = new CloudConvertAPI(apiKey);

    //  var req = new ImportUploadData
    //  {
    //    Operation = ImportOperation.ImportUpload.GetEnumDescription()
    //  };

    //  var task = ccAPI.CreateTaskAsync(ImportOperation.ImportUpload.GetEnumDescription(), req);

    //  var path = @"TestFiles\Test.pdf";
    //  using var stream = new FileStream(path, FileMode.Open);
    //  var result = await ccAPI.UploadAsync(new StreamPart(stream, "test-streampart.pdf", "application/pdf"));

    //}
  }
}
