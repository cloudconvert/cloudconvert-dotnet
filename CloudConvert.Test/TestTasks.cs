using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using CloudConvert.API;
using CloudConvert.API.Models;
using CloudConvert.API.Models.ImportOperations;
using CloudConvert.API.Models.TaskModels;
using CloudConvert.API.Models.TaskOperations;
using CloudConvert.Test.Extensions;
using Moq;
using Moq.Protected;
using System.Text.Json;
using NUnit.Framework;

namespace CloudConvert.Test
{
  public class TestTasks
  {
    [Test]
    public async Task GetAllTasks()
    {
      try
      {
        TaskListFilter filter = new TaskListFilter();

        var path = @"Responses/tasks.json";
        string json = File.ReadAllText(path);

        var cloudConvertApi = new Mock<ICloudConvertAPI>();
        cloudConvertApi.Setup(cc => cc.GetAllTasksAsync(filter))
                       .ReturnsAsync(JsonSerializer.Deserialize<ListResponse<TaskResponse>>(json, DefaultJsonSerializerOptions.SerializerOptions));

        var tasks = await cloudConvertApi.Object.GetAllTasksAsync(filter);

        Assert.IsNotNull(tasks);
        Assert.IsTrue(tasks.Data.Count >= 0);
      }
      catch (WebApiException ex)
      {
        if (ex.InnerException != null)
        {
          var error = JsonSerializer.Deserialize<ErrorResponse>(ex.InnerException.Message, DefaultJsonSerializerOptions.SerializerOptions);
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
      var req = new ConvertCreateRequest
      {
        Input = "9ebdb9c7-ee41-4c08-9fb7-1f342289f712", //Guid import
        Input_Format = "pdf",
        Output_Format = "docx",
        Engine = "bcl"
      };

      var path = AppDomain.CurrentDomain.BaseDirectory + @"Responses/task_created.json";
      string json = File.ReadAllText(path);

      var cloudConvertApi = new Mock<ICloudConvertAPI>();
      cloudConvertApi.Setup(cc => cc.CreateTaskAsync(req.Operation, req))
                     .ReturnsAsync(JsonSerializer.Deserialize<Response<TaskResponse>>(json, DefaultJsonSerializerOptions.SerializerOptions));

      var task = await cloudConvertApi.Object.CreateTaskAsync(req.Operation, req);

      Assert.IsNotNull(task);
      Assert.IsTrue(task.Data.Status == API.Models.Enums.TaskStatus.waiting);
    }

    [Test]
    public async Task GetTask()
    {
      string id = "9de1a620-952c-4482-9d44-681ae28d72a1";

      var path = AppDomain.CurrentDomain.BaseDirectory + @"Responses/task.json";
      string json = File.ReadAllText(path);

      var _cloudConvertAPI = new Mock<ICloudConvertAPI>();
      _cloudConvertAPI.Setup(cc => cc.GetTaskAsync(id, null))
                      .ReturnsAsync(JsonSerializer.Deserialize<Response<TaskResponse>>(json, DefaultJsonSerializerOptions.SerializerOptions));

      var task = await _cloudConvertAPI.Object.GetTaskAsync("9de1a620-952c-4482-9d44-681ae28d72a1");

      Assert.IsNotNull(task);
      Assert.IsTrue(task.Data.Operation == "convert");
    }

    [Test]
    public async Task WaitTask()
    {
      string id = "9de1a620-952c-4482-9d44-681ae28d72a1";

      var path = AppDomain.CurrentDomain.BaseDirectory + @"Responses/task.json";
      string json = File.ReadAllText(path);

      var cloudConvertApi = new Mock<ICloudConvertAPI>();
      cloudConvertApi.Setup(cc => cc.WaitTaskAsync(id))
                      .ReturnsAsync(JsonSerializer.Deserialize<Response<TaskResponse>>(json, DefaultJsonSerializerOptions.SerializerOptions));

      var task = await cloudConvertApi.Object.WaitTaskAsync(id);

      Assert.IsNotNull(task);
      Assert.IsTrue(task.Data.Operation == "convert");
      Assert.AreEqual(task.Data.Status, API.Models.Enums.TaskStatus.finished);
    }

    [Test]
    public async Task DeleteTask()
    {
      string id = "9de1a620-952c-4482-9d44-681ae28d72a1";

      var cloudConvertApi = new Mock<ICloudConvertAPI>();
      cloudConvertApi.Setup(cc => cc.DeleteTaskAsync(id));

      await cloudConvertApi.Object.DeleteTaskAsync("c8a8da46-3758-45bf-b983-2510e3170acb");
    }

    [Test]
    public async Task Upload()
    {
      var cloudConvertApi = new Mock<ICloudConvertAPI>();
      var req = new ImportUploadCreateRequest();

      var path = AppDomain.CurrentDomain.BaseDirectory + @"Responses/upload_task_created.json";
      string json = File.ReadAllText(path);
      cloudConvertApi.Setup(cc => cc.CreateTaskAsync(req.Operation, req))
                      .ReturnsAsync(JsonSerializer.Deserialize<Response<TaskResponse>>(json, DefaultJsonSerializerOptions.SerializerOptions));

      var task = await cloudConvertApi.Object.CreateTaskAsync(req.Operation, req);

      Assert.IsNotNull(task);

      var pathFile = AppDomain.CurrentDomain.BaseDirectory + @"TestFiles/input.pdf";
      byte[] file = File.ReadAllBytes(pathFile);
      string fileName = "input.pdf";

      cloudConvertApi.Setup(cc => cc.UploadAsync(task.Data.Result.Form.Url.ToString(), file, fileName, task.Data.Result.Form.Parameters));

      await cloudConvertApi.Object.UploadAsync(task.Data.Result.Form.Url.ToString(), file, fileName, task.Data.Result.Form.Parameters);
    }

    [Test]
    public async Task UploadStream()
    {
      var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
      httpMessageHandlerMock.MockResponse("/import/upload", "upload_task_created.json");
      httpMessageHandlerMock.MockResponse("/tasks", "tasks.json");

      var httpClient = new HttpClient(httpMessageHandlerMock.Object);
      var restHelper = new RestHelper(httpClient);
      var req = new ImportUploadCreateRequest();
      var cloudConvertApi = new CloudConvertAPI(restHelper, "API_KEY");

      var task = await cloudConvertApi.CreateTaskAsync(req.Operation, req);

      Assert.IsNotNull(task);
      httpMessageHandlerMock.VerifyRequest("/import/upload", Times.Once());

      var streamMock = new Mock<Stream>();
      var fileName = "input.pdf";

      await cloudConvertApi.UploadAsync(task.Data.Result.Form.Url.ToString(), streamMock.Object, fileName, task.Data.Result.Form.Parameters);

      httpMessageHandlerMock.VerifyRequest("/tasks", Times.Once());
      streamMock.Protected().Verify("Dispose", Times.Never(), args: true);
    }
  }
}
