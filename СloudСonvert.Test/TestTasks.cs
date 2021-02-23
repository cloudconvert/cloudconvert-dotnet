using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using Refit;
using СloudСonvert.API;
using СloudСonvert.API.СloudСonvert;
using СloudСonvert.API.СloudСonvert.Models;
using СloudСonvert.API.СloudСonvert.Models.TaskModels;

namespace СloudСonvert.Test
{
  public class TestTasks
  {
    const string urlApi = "https://api.cloudconvert.com/v2";
    const string apiKey = "";

    [Test]
    public async Task GetAllTasks()
    {
      CloudConvertAPI ccAPI = new CloudConvertAPI(urlApi, apiKey);
      try
      {
        TaskFilter filter = new TaskFilter();
        var result = await ccAPI.GetAllTasksAsync(filter);
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
    public async Task GetTask()
    {
      CloudConvertAPI ccAPI = new CloudConvertAPI(urlApi, apiKey);

      var result = await ccAPI.GetTaskAsync("db14fa95-9cf3-482c-92d1-34c26551bba0");
    }

    [Test]
    public async Task WaitTask()
    {
      CloudConvertAPI ccAPI = new CloudConvertAPI(urlApi, apiKey);

      var result = await ccAPI.WaitTaskAsync("c8a8da46-3758-45bf-b983-2510e3170acb");
    }

    [Test]
    public async Task DeleteTask()
    {
      CloudConvertAPI ccAPI = new CloudConvertAPI(urlApi, apiKey);

      await ccAPI.DeleteTaskAsync("c8a8da46-3758-45bf-b983-2510e3170acb");
    }

  }
}
