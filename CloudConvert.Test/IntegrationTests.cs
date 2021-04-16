using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using CloudConvert.API;
using CloudConvert.API.Models.Enums;
using CloudConvert.API.Models.ExportOperations;
using CloudConvert.API.Models.ImportOperations;
using CloudConvert.API.Models.TaskOperations;
using CloudConvert.API.Models.JobModels;

using System.Collections.Generic;
using System;

namespace CloudConvert.Test
{
  [Category("Integration")]
  public class IntegrationTests
  {
    const string apiKey = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImp0aSI6IjI4YmE3OGQyZjc1NWM5ZGE3Yjg1NDRhMWRkMjg2NWM4N2U0YzI5NWI0NzQ0Zjc4ZDNmMzA3OWM2NjU3ZjI0MjVhOTMyYjIxMjU5ZGU2NWQ4In0.eyJhdWQiOiIxIiwianRpIjoiMjhiYTc4ZDJmNzU1YzlkYTdiODU0NGExZGQyODY1Yzg3ZTRjMjk1YjQ3NDRmNzhkM2YzMDc5YzY2NTdmMjQyNWE5MzJiMjEyNTlkZTY1ZDgiLCJpYXQiOjE1NTkwNjc3NzcsIm5iZiI6MTU1OTA2Nzc3NywiZXhwIjo0NzE0NzQxMzc3LCJzdWIiOiIzNzExNjc4NCIsInNjb3BlcyI6WyJ1c2VyLnJlYWQiLCJ1c2VyLndyaXRlIiwidGFzay5yZWFkIiwidGFzay53cml0ZSIsIndlYmhvb2sucmVhZCIsIndlYmhvb2sud3JpdGUiXX0.IkmkfDVGwouCH-ICFAShQMHyFAHK3y90CSoissUVD8h5HFG4GqN5DEw0IFzlPr1auUKp3H1pAvPutdIQtrDMTmUUmGMUb2dRlCAuQdqxa81Q5KAmcKDgOg2YTWOWEGMy3jETTb7W6vyNGsT_3DFMapMdeOw1jdIUTMZqW3QbSCeGXj3PMRnhI7YynaDtmktjzO9IUDHbeT2HRzzMiep97KvVZNjYtZvgM-kbUjE6Mm68_kA8JMuQeor0Yg7896JPV0YM3-MnHf7elKgoCJbfBCDAbvSX_ZYsSI7IGoLLb0mgJVfFcH_HMYAHhJj5cUEJN2Iml-FkODqrRk72bVxyJs9j1GPQBl4ORXuU9yrjUgHrRaZ5YM__LwsUQB3AuB92oyQseCjULn1sWM1PzIXCcyVjKZSpn9LAAGNf9paCF-_G9ok9tZKccRouCiYl9v5XbmuxV8hXYp6fXZxyaAkj_JN2kErVSkxYzVyyZL1e220aFFnbch6nDvLFHgi-WeTQHFQDzuHsM8RKRixV8uD7pk3de4AEYg0EWqZHCr82qY7TGdSQvuAS0QIy3B89OwQW0ROW4k3Yw0XIKgKSYWyKnc7huc7yPQUIDDDAOa5OojXrVY5ZuL_hwQMIOmejcHTKFdAgzAaVnRkC8_FfVh4wHCPBaHjze9hRp5n4O1pnPFI";
    protected ICloudConvertAPI _cloudConvertAPI;

    [OneTimeSetUp]
    public void Setup()
    {
      _cloudConvertAPI = new CloudConvertAPI(apiKey, true);
    }

    [Test]
    public async Task CreateJob()
    {
      var job = await _cloudConvertAPI.CreateJobAsync(new JobCreateRequest
      {
        Tasks = new
        {
          import_it = new ImportUploadCreateRequest(),
          export_it = new ExportUrlCreateRequest
          {
            Input = "import_it"
          }
        },
        Tag = "integration-test-upload-download"
      });

      var uploadTask = job.Data.Tasks.FirstOrDefault(t => t.Name == "import_it");

      Assert.IsNotNull(uploadTask);

      var path = AppDomain.CurrentDomain.BaseDirectory + @"TestFiles/input.pdf";
      byte[] file = File.ReadAllBytes(path);
      string fileName = "input.pdf";

      var result = await _cloudConvertAPI.UploadAsync(uploadTask.Result.Form.Url.ToString(), file, fileName, uploadTask.Result.Form.Parameters);

      job = await _cloudConvertAPI.WaitJobAsync(job.Data.Id);

      Assert.AreEqual(job.Data.Status, "finished");

      // download export file

      var exportTask = job.Data.Tasks.FirstOrDefault(t => t.Name == "export_it");

      var fileExport = exportTask.Result.Files.FirstOrDefault();

      Assert.IsNotNull(fileExport);
      Assert.AreEqual(fileExport.Filename, "input.pdf");

      using (var client = new WebClient()) client.DownloadFile(fileExport.Url, fileExport.Filename);
    }

    [Test]
    public async Task CreateTask()
    {
      // import

      var reqImport = new ImportUploadCreateRequest();

      var importTask = await _cloudConvertAPI.CreateTaskAsync(ImportUploadCreateRequest.Operation, reqImport);

      var path = AppDomain.CurrentDomain.BaseDirectory + @"TestFiles/input.pdf";
      byte[] file = File.ReadAllBytes(path);
      string fileName = "input.pdf";

      await _cloudConvertAPI.UploadAsync(importTask.Data.Result.Form.Url.ToString(), file, fileName, importTask.Data.Result.Form.Parameters);

      importTask = await _cloudConvertAPI.WaitTaskAsync(importTask.Data.Id);

      Assert.IsNotNull(importTask);
      Assert.AreEqual(importTask.Data.Status, API.Models.Enums.TaskStatus.finished);

      // export

      var reqExport = new ExportUrlCreateRequest
      {
        Input = importTask.Data.Id
      };

      var exportTask = await _cloudConvertAPI.CreateTaskAsync(ExportUrlCreateRequest.Operation, reqExport);

      Assert.IsNotNull(exportTask);

      exportTask = await _cloudConvertAPI.WaitTaskAsync(exportTask.Data.Id);

      Assert.IsNotNull(exportTask);
      Assert.IsTrue(exportTask.Data.Status == API.Models.Enums.TaskStatus.finished);

      var fileExport = exportTask.Data.Result.Files.FirstOrDefault();

      Assert.IsNotNull(fileExport);
      Assert.AreEqual(fileExport.Filename, "input.pdf");

      using (var client = new WebClient()) client.DownloadFile(fileExport.Url, fileExport.Filename);

    }
  }
}
