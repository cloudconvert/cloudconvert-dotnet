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
  public class SandboxTasks
  {
    const string sandboxUrlApi = "https://api.sandbox.cloudconvert.com/v2/";
    const string apiKey = "";

    [Test]
    public async Task GetAllTasks()
    {
      CloudConvertAPI ccAPI = new CloudConvertAPI(sandboxUrlApi, apiKey);
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
      CloudConvertAPI ccAPI = new CloudConvertAPI(sandboxUrlApi, apiKey);

      var result = await ccAPI.GetTaskAsync("c8a8da46-3758-45bf-b983-2510e3170acb");
    }

    [Test]
    public async Task WaitTask()
    {
      CloudConvertAPI ccAPI = new CloudConvertAPI(sandboxUrlApi, apiKey);

      var result = await ccAPI.WaitTaskAsync("c8a8da46-3758-45bf-b983-2510e3170acb");
    }

    [Test]
    public async Task DeleteTask()
    {
      CloudConvertAPI ccAPI = new CloudConvertAPI(sandboxUrlApi, apiKey);

      await ccAPI.DeleteTaskAsync("c8a8da46-3758-45bf-b983-2510e3170acb");
    }

  }
}
