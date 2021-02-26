using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using CloudConvert.API;
using CloudConvert.API.Models;
using CloudConvert.API.Models.Enums;
using CloudConvert.API.Models.ExportOperations;
using CloudConvert.API.Models.ImportOperations;
using CloudConvert.API.Models.TaskModels;
using CloudConvert.API.Models.TaskOperations;
using Moq;

namespace CloudConvert.Test
{
  public class TestTasks
  {
    const string apiKey = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIxIiwianRpIjoiMDM5MGQ3Njk4N2I3NzY1YjMyZTJhMTRjYjIzOTUzYTc0YzNmMTEyOWY5MzU5M2E5ODdhZjUxM2YzYWY5YmZjNzU1YjZkMTUzMjMwM2Y5MjEiLCJpYXQiOjE2MTM3NDAzNTAsIm5iZiI6MTYxMzc0MDM1MCwiZXhwIjo0NzY5NDEzOTUwLCJzdWIiOiIyMzAwNjM4OSIsInNjb3BlcyI6WyJ1c2VyLnJlYWQiLCJ1c2VyLndyaXRlIiwidGFzay5yZWFkIiwidGFzay53cml0ZSIsIndlYmhvb2sucmVhZCIsIndlYmhvb2sud3JpdGUiLCJwcmVzZXQucmVhZCIsInByZXNldC53cml0ZSJdfQ.A-mMEGul6IEPUUkga7iTnjBrcSZnPNfLVOiN7CRLK29jOaZBL0eIuZtsao8E9uUqqgoXy1KLDUelh5WyzsO4w34KYQojgVJsZKEU86QCbVsJQXXnaSXbXPoTlyugnHdEKqnncBNqgbSbKMOOZhiglXLRk7IXAOl8ai4PmaW9_yymqlz4NH95RtM7CDIm5Ej1i4u517-1fdd3QQKeJAYLVi_Xt_vgfWYATf0JIT_2r2ED1-sk2DWALtonvFiR-HRZX7SltftWWWct9OjxcGigC45hxLke3Ln-VhthySIebo48hbE89UYWCkh8ElzRT2UpVNE1S7LNYJxfAimjh2DZpfyJALVQNJXUrbMLDWJeDJDAgcKyzeElllioxxTY2K-wmDi2HiVzB-j6qMgAoueAfhyshoTtUouLGpZeX51GWv6kr74Fn31WYihevlDDrpkmgNfCKkVPt__tx6SI5Qh-cvGLgwT-x1QK0jQxeSjXm1N6NLH4jDN0qh88eWDrG1KsRqRwKRtWOnWRYTEehUgoEkmRBG8bXPB6MuFRaoWiav-tZ41kxya8jORWGAYoUuMbtKJS8WxzTYEV8ipnQo8sLHI7Jt27TMZAHZTBSYsOQUY9aUxN6f40eXdUY7Uw33zNCam-vUcTvZ46cwdCdlI3KRjXXoM6_cFS1RUhDEZWcr4";
    readonly ICloudConvertAPI _cloudConvertAPI = new CloudConvertAPI(apiKey, true);
    readonly Mock<ICloudConvertAPI> _cloudConvertAPI1 = new Mock<ICloudConvertAPI>();

    [Test]
    public async Task GetAllTasks()
    {
      try
      {
        TaskFilter filter = new TaskFilter();

        var path = @"Responses\tasks.json";
        string json = File.ReadAllText(path);
        _cloudConvertAPI1.Setup(cc => cc.GetAllTasksAsync(filter))
                        .ReturnsAsync(JsonConvert.DeserializeObject<TasksResponse>(json));

        var tasks = await _cloudConvertAPI1.Object.GetAllTasksAsync(filter);

        Assert.IsNotNull(tasks);
        Assert.IsTrue(tasks.Data.Count >= 0);
      }
      catch (WebApiException ex)
      {
        if (ex.InnerException != null)
        {
          var error = JsonConvert.DeserializeObject<ErrorResponse>(ex.InnerException.Message);
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
      var req = new TaskConvertCreateRequest
      {
        Input = "9ebdb9c7-ee41-4c08-9fb7-1f342289f712", //Guid import
        Input_Format = "pdf",
        Output_Format = "docx",
        Engine = "bcl"
      };

      var path = @"Responses\task_created.json";
      string json = File.ReadAllText(path);
      _cloudConvertAPI1.Setup(cc => cc.CreateTaskAsync(TaskConvertCreateRequest.Operation, req))
                      .ReturnsAsync(JsonConvert.DeserializeObject<TaskResponse>(json));

      var task = await _cloudConvertAPI1.Object.CreateTaskAsync(TaskConvertCreateRequest.Operation, req);

      Assert.IsNotNull(task);
      Assert.IsTrue(task.Data.Status == TaskCCStatus.waiting);
    }

    [Test]
    public async Task GetTask()
    {
      string id = "9de1a620-952c-4482-9d44-681ae28d72a1";

      var path = @"Responses\task.json";
      string json = File.ReadAllText(path);
      _cloudConvertAPI1.Setup(cc => cc.GetTaskAsync(id, null))
                      .ReturnsAsync(JsonConvert.DeserializeObject<TaskResponse>(json));

      var task = await _cloudConvertAPI1.Object.GetTaskAsync("9de1a620-952c-4482-9d44-681ae28d72a1");

      Assert.IsNotNull(task);
      Assert.IsTrue(task.Data.Operation == "convert");
    }

    [Test]
    public async Task WaitTask()
    {
      string id = "9de1a620-952c-4482-9d44-681ae28d72a1";

      var path = @"Responses\task.json";
      string json = File.ReadAllText(path);
      _cloudConvertAPI1.Setup(cc => cc.WaitTaskAsync(id))
                      .ReturnsAsync(JsonConvert.DeserializeObject<TaskResponse>(json));

      var task = await _cloudConvertAPI1.Object.WaitTaskAsync(id);

      Assert.IsNotNull(task);
      Assert.IsTrue(task.Data.Operation == "convert");
      Assert.AreEqual(task.Data.Status, TaskCCStatus.finished);
    }

    [Test]
    public async Task DeleteTask()
    {
      string id = "9de1a620-952c-4482-9d44-681ae28d72a1";

      _cloudConvertAPI1.Setup(cc => cc.DeleteTaskAsync(id));

      await _cloudConvertAPI1.Object.DeleteTaskAsync("c8a8da46-3758-45bf-b983-2510e3170acb");
    }

    [Test]
    public async Task Upload()
    {
      var req = new ImportUploadData();

      var path = @"Responses\upload_task_created.json";
      string json = File.ReadAllText(path);
      _cloudConvertAPI1.Setup(cc => cc.CreateTaskAsync(ImportUploadData.Operation, req))
                      .ReturnsAsync(JsonConvert.DeserializeObject<TaskResponse>(json));

      var task = await _cloudConvertAPI1.Object.CreateTaskAsync(ImportUploadData.Operation, req);

      Assert.IsNotNull(task);

      var pathFile = @"TestFiles\input.pdf";
      byte[] file = await File.ReadAllBytesAsync(pathFile);
      string fileName = "input.pdf";

      _cloudConvertAPI1.Setup(cc => cc.UploadAsync(task.Data.Result.Form.Url.ToString(), file, fileName, task.Data.Result.Form.Parameters));

      await _cloudConvertAPI1.Object.UploadAsync(task.Data.Result.Form.Url.ToString(), file, fileName, task.Data.Result.Form.Parameters);
    }
  }
}
