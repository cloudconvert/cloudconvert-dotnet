using System;
using System.IO;
using System.Threading.Tasks;
using CloudConvert.API;
using CloudConvert.API.Models;
using CloudConvert.API.Models.Enums;
using CloudConvert.API.Models.ImportOperations;
using CloudConvert.API.Models.TaskModels;
using CloudConvert.API.Models.TaskOperations;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CloudConvert.Test
{
  public class TestTasks
  {
    readonly Mock<ICloudConvertAPI> _cloudConvertAPI = new Mock<ICloudConvertAPI>();

    [Test]
    public async Task GetAllTasks()
    {
      try
      {
        TaskListFilter filter = new TaskListFilter();

        var path = @"Responses/tasks.json";
        string json = File.ReadAllText(path);
        _cloudConvertAPI.Setup(cc => cc.GetAllTasksAsync(filter))
                        .ReturnsAsync(JsonConvert.DeserializeObject<ListResponse<TaskResponse>>(json));

        var tasks = await _cloudConvertAPI.Object.GetAllTasksAsync(filter);

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
        var error = ex.Message;
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

      var path = @"Responses/task_created.json";
      string json = File.ReadAllText(path);
      _cloudConvertAPI.Setup(cc => cc.CreateTaskAsync(TaskConvertCreateRequest.Operation, req))
                      .ReturnsAsync(JsonConvert.DeserializeObject<Response<TaskResponse>>(json));

      var task = await _cloudConvertAPI.Object.CreateTaskAsync(TaskConvertCreateRequest.Operation, req);

      Assert.IsNotNull(task);
      Assert.IsTrue(task.Data.Status == API.Models.Enums.TaskStatus.waiting);
    }

    [Test]
    public async Task GetTask()
    {
      string id = "9de1a620-952c-4482-9d44-681ae28d72a1";

      var path = @"Responses/task.json";
      string json = File.ReadAllText(path);
      _cloudConvertAPI.Setup(cc => cc.GetTaskAsync(id, null))
                      .ReturnsAsync(JsonConvert.DeserializeObject<Response<TaskResponse>>(json));

      var task = await _cloudConvertAPI.Object.GetTaskAsync("9de1a620-952c-4482-9d44-681ae28d72a1");

      Assert.IsNotNull(task);
      Assert.IsTrue(task.Data.Operation == "convert");
    }

    [Test]
    public async Task WaitTask()
    {
      string id = "9de1a620-952c-4482-9d44-681ae28d72a1";

      var path = @"Responses/task.json";
      string json = File.ReadAllText(path);
      _cloudConvertAPI.Setup(cc => cc.WaitTaskAsync(id))
                      .ReturnsAsync(JsonConvert.DeserializeObject<Response<TaskResponse>>(json));

      var task = await _cloudConvertAPI.Object.WaitTaskAsync(id);

      Assert.IsNotNull(task);
      Assert.IsTrue(task.Data.Operation == "convert");
      Assert.AreEqual(task.Data.Status, API.Models.Enums.TaskStatus.finished);
    }

    [Test]
    public async Task DeleteTask()
    {
      string id = "9de1a620-952c-4482-9d44-681ae28d72a1";

      _cloudConvertAPI.Setup(cc => cc.DeleteTaskAsync(id));

      await _cloudConvertAPI.Object.DeleteTaskAsync("c8a8da46-3758-45bf-b983-2510e3170acb");
    }

    [Test]
    public async Task Upload()
    {
      var req = new ImportUploadCreateRequest();

      var path = @"Responses/upload_task_created.json";
      string json = File.ReadAllText(path);
      _cloudConvertAPI.Setup(cc => cc.CreateTaskAsync(ImportUploadCreateRequest.Operation, req))
                      .ReturnsAsync(JsonConvert.DeserializeObject<Response<TaskResponse>>(json));

      var task = await _cloudConvertAPI.Object.CreateTaskAsync(ImportUploadCreateRequest.Operation, req);

      Assert.IsNotNull(task);

      var pathFile = @"TestFiles/input.pdf";
      byte[] file = await File.ReadAllBytesAsync(pathFile);
      string fileName = "input.pdf";

      _cloudConvertAPI.Setup(cc => cc.UploadAsync(task.Data.Result.Form.Url.ToString(), file, fileName, task.Data.Result.Form.Parameters));

      await _cloudConvertAPI.Object.UploadAsync(task.Data.Result.Form.Url.ToString(), file, fileName, task.Data.Result.Form.Parameters);
    }
  }
}
