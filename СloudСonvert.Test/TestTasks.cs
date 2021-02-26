using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using СloudСonvert.API;
using СloudСonvert.API.Models;
using СloudСonvert.API.Models.Enums;
using СloudСonvert.API.Models.ExportOperations;
using СloudСonvert.API.Models.ImportOperations;
using СloudСonvert.API.Models.TaskModels;
using СloudСonvert.API.Models.TaskOperations;

namespace СloudСonvert.Test
{
  public class TestTasks
  {
    const string apiKey = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIxIiwianRpIjoiMDM5MGQ3Njk4N2I3NzY1YjMyZTJhMTRjYjIzOTUzYTc0YzNmMTEyOWY5MzU5M2E5ODdhZjUxM2YzYWY5YmZjNzU1YjZkMTUzMjMwM2Y5MjEiLCJpYXQiOjE2MTM3NDAzNTAsIm5iZiI6MTYxMzc0MDM1MCwiZXhwIjo0NzY5NDEzOTUwLCJzdWIiOiIyMzAwNjM4OSIsInNjb3BlcyI6WyJ1c2VyLnJlYWQiLCJ1c2VyLndyaXRlIiwidGFzay5yZWFkIiwidGFzay53cml0ZSIsIndlYmhvb2sucmVhZCIsIndlYmhvb2sud3JpdGUiLCJwcmVzZXQucmVhZCIsInByZXNldC53cml0ZSJdfQ.A-mMEGul6IEPUUkga7iTnjBrcSZnPNfLVOiN7CRLK29jOaZBL0eIuZtsao8E9uUqqgoXy1KLDUelh5WyzsO4w34KYQojgVJsZKEU86QCbVsJQXXnaSXbXPoTlyugnHdEKqnncBNqgbSbKMOOZhiglXLRk7IXAOl8ai4PmaW9_yymqlz4NH95RtM7CDIm5Ej1i4u517-1fdd3QQKeJAYLVi_Xt_vgfWYATf0JIT_2r2ED1-sk2DWALtonvFiR-HRZX7SltftWWWct9OjxcGigC45hxLke3Ln-VhthySIebo48hbE89UYWCkh8ElzRT2UpVNE1S7LNYJxfAimjh2DZpfyJALVQNJXUrbMLDWJeDJDAgcKyzeElllioxxTY2K-wmDi2HiVzB-j6qMgAoueAfhyshoTtUouLGpZeX51GWv6kr74Fn31WYihevlDDrpkmgNfCKkVPt__tx6SI5Qh-cvGLgwT-x1QK0jQxeSjXm1N6NLH4jDN0qh88eWDrG1KsRqRwKRtWOnWRYTEehUgoEkmRBG8bXPB6MuFRaoWiav-tZ41kxya8jORWGAYoUuMbtKJS8WxzTYEV8ipnQo8sLHI7Jt27TMZAHZTBSYsOQUY9aUxN6f40eXdUY7Uw33zNCam-vUcTvZ46cwdCdlI3KRjXXoM6_cFS1RUhDEZWcr4";
    readonly ICloudConvertAPI _cloudConvertAPI = new CloudConvertAPI(apiKey, true);

    [Test]
    public async Task GetAllTasks()
    {
      try
      {
        TaskFilter filter = new TaskFilter();
        var result = await _cloudConvertAPI.GetAllTasksAsync(filter);

        Assert.IsNotNull(result);
        Assert.IsTrue(result.Data.Count >= 0);
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
      var req = new TaskConvertCreateData
      {
        Input = "1d9f85de-360a-428d-aed2-a8e568c6c46f", //Guid import
        Input_Format = "pdf",
        Output_Format = "docx",
        Engine = "bcl"
      };

      var result = await _cloudConvertAPI.CreateTaskAsync(TaskConvertCreateData.Operation, req);

      Assert.IsNotNull(result);
      Assert.IsTrue(result.Data.Status == TaskCCStatus.waiting);
    }

    [Test]
    public async Task GetTask()
    {
      var result = await _cloudConvertAPI.GetTaskAsync("e87282ad-522f-4aec-9d71-7dde411774d3");

      Assert.IsNotNull(result);
      Assert.IsTrue(result.Data.Operation == "convert");
      Assert.AreEqual(result.Data.Status, TaskCCStatus.waiting);
    }

    [Test]
    public async Task WaitTask()
    {
      var result = await _cloudConvertAPI.WaitTaskAsync("34b8dd4c-2d47-4728-88da-ed1f089e5134");

      Assert.IsNotNull(result);
      Assert.IsTrue(result.Data.Operation == "export/url");
      Assert.AreEqual(result.Data.Status, TaskCCStatus.finished);
    }

    [Test]
    public async Task DeleteTask()
    {
      await _cloudConvertAPI.DeleteTaskAsync("c8a8da46-3758-45bf-b983-2510e3170acb");
    }

    [Test]
    public async Task Upload()
    {
      var req = new ImportUploadData();

      var task = await _cloudConvertAPI.CreateTaskAsync(ImportUploadData.Operation, req);

      var path = @"TestFiles\test.pdf";
      byte[] file = await File.ReadAllBytesAsync(path);
      string fileName = "test.pdf";

      var result = await _cloudConvertAPI.UploadAsync(task.Data.Result.Form.Url.ToString(), file, fileName, task.Data.Result.Form.Parameters);

      Assert.IsNotNull(result);
    }

    [Test]
    public async Task Download()
    {
      var req = new ExportUrlData
      {
        Input = "989a5f99-80c9-4746-94cb-47f3b6a7e98f", //Guid id import
        Archive_Multiple_Files = false
      };

      var result = await _cloudConvertAPI.CreateTaskAsync(ExportUrlData.Operation, req);

      Assert.IsNotNull(result);

      var task = await _cloudConvertAPI.WaitTaskAsync(result.Data.Id);

      Assert.IsNotNull(task);
      Assert.IsTrue(task.Data.Status == TaskCCStatus.finished);

      foreach (var file in task.Data.Result.Files)
      {
        using (var client = new WebClient()) client.DownloadFile(file.Url, file.Filename);
      }
    }
  }
}
