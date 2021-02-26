using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using CloudConvert.API;
using CloudConvert.API.Models.Enums;
using CloudConvert.API.Models.ExportOperations;
using CloudConvert.API.Models.ImportOperations;
using CloudConvert.API.Models.JobModels;

namespace CloudConvert.Test
{
  [Category("Integration")]
  public class IntegrationTests
  {
    const string apiKey = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIxIiwianRpIjoiMDM5MGQ3Njk4N2I3NzY1YjMyZTJhMTRjYjIzOTUzYTc0YzNmMTEyOWY5MzU5M2E5ODdhZjUxM2YzYWY5YmZjNzU1YjZkMTUzMjMwM2Y5MjEiLCJpYXQiOjE2MTM3NDAzNTAsIm5iZiI6MTYxMzc0MDM1MCwiZXhwIjo0NzY5NDEzOTUwLCJzdWIiOiIyMzAwNjM4OSIsInNjb3BlcyI6WyJ1c2VyLnJlYWQiLCJ1c2VyLndyaXRlIiwidGFzay5yZWFkIiwidGFzay53cml0ZSIsIndlYmhvb2sucmVhZCIsIndlYmhvb2sud3JpdGUiLCJwcmVzZXQucmVhZCIsInByZXNldC53cml0ZSJdfQ.A-mMEGul6IEPUUkga7iTnjBrcSZnPNfLVOiN7CRLK29jOaZBL0eIuZtsao8E9uUqqgoXy1KLDUelh5WyzsO4w34KYQojgVJsZKEU86QCbVsJQXXnaSXbXPoTlyugnHdEKqnncBNqgbSbKMOOZhiglXLRk7IXAOl8ai4PmaW9_yymqlz4NH95RtM7CDIm5Ej1i4u517-1fdd3QQKeJAYLVi_Xt_vgfWYATf0JIT_2r2ED1-sk2DWALtonvFiR-HRZX7SltftWWWct9OjxcGigC45hxLke3Ln-VhthySIebo48hbE89UYWCkh8ElzRT2UpVNE1S7LNYJxfAimjh2DZpfyJALVQNJXUrbMLDWJeDJDAgcKyzeElllioxxTY2K-wmDi2HiVzB-j6qMgAoueAfhyshoTtUouLGpZeX51GWv6kr74Fn31WYihevlDDrpkmgNfCKkVPt__tx6SI5Qh-cvGLgwT-x1QK0jQxeSjXm1N6NLH4jDN0qh88eWDrG1KsRqRwKRtWOnWRYTEehUgoEkmRBG8bXPB6MuFRaoWiav-tZ41kxya8jORWGAYoUuMbtKJS8WxzTYEV8ipnQo8sLHI7Jt27TMZAHZTBSYsOQUY9aUxN6f40eXdUY7Uw33zNCam-vUcTvZ46cwdCdlI3KRjXXoM6_cFS1RUhDEZWcr4";
    protected ICloudConvertAPI _cloudConvertAPI;

    [OneTimeSetUp]
    public void Setup()
    {
      _cloudConvertAPI = new CloudConvertAPI(apiKey, true);
    }

    [Test]
    public async Task CreateJob()
    {
      var req = new JobCreateRequest
      {
        Tasks = new
        {
          import_it = new ImportUploadData(),
          export_it = new ExportUrlData
          {
            Input = "import_it"
          }
        },
        Tag = "integration-test-upload-download"
      };

      var job = await _cloudConvertAPI.CreateJobAsync(req);

      var uploadTask = job.Data.Tasks.FirstOrDefault(t => t.Name == "import_it");

      Assert.IsNotNull(uploadTask);

      var path = @"TestFiles\test.pdf";
      byte[] file = await File.ReadAllBytesAsync(path);
      string fileName = "test.pdf";

      var result = await _cloudConvertAPI.UploadAsync(uploadTask.Result.Form.Url.ToString(), file, fileName, uploadTask.Result.Form.Parameters);

      job = await _cloudConvertAPI.WaitJobAsync(job.Data.Id);

      Assert.AreEqual(job.Data.Status, "finished");

      // download export file

      var exportTask = job.Data.Tasks.FirstOrDefault(t => t.Name == "export_it");

      var fileExport = exportTask.Result.Files.FirstOrDefault();

      Assert.IsNotNull(fileExport);
      Assert.AreEqual(fileExport.Filename, "test.pdf");

      using (var client = new WebClient()) client.DownloadFile(fileExport.Url, fileExport.Filename);
    }

    [Test]
    public async Task CreateTask()
    {
      // import

      var reqImport = new ImportUploadData();

      var importTask = await _cloudConvertAPI.CreateTaskAsync(ImportUploadData.Operation, reqImport);

      var path = @"TestFiles\test.pdf";
      byte[] file = await File.ReadAllBytesAsync(path);
      string fileName = "test.pdf";

      await _cloudConvertAPI.UploadAsync(importTask.Data.Result.Form.Url.ToString(), file, fileName, importTask.Data.Result.Form.Parameters);

      importTask = await _cloudConvertAPI.WaitTaskAsync(importTask.Data.Id);

      Assert.IsNotNull(importTask);
      Assert.AreEqual(importTask.Data.Status, TaskCCStatus.finished);

      // export

      var reqExport = new ExportUrlData
      {
        Input = importTask.Data.Id
      };

      var exportTask = await _cloudConvertAPI.CreateTaskAsync(ExportUrlData.Operation, reqExport);

      Assert.IsNotNull(exportTask);

      exportTask = await _cloudConvertAPI.WaitTaskAsync(exportTask.Data.Id);

      Assert.IsNotNull(exportTask);
      Assert.IsTrue(exportTask.Data.Status == TaskCCStatus.finished);

      var fileExport = exportTask.Data.Result.Files.FirstOrDefault();

      Assert.IsNotNull(fileExport);
      Assert.AreEqual(fileExport.Filename, "test.pdf");

      using (var client = new WebClient()) client.DownloadFile(fileExport.Url, fileExport.Filename);

    }
  }
}
