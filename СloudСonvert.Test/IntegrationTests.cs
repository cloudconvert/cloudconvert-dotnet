using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using СloudСonvert.API;
using СloudСonvert.API.Extensions;
using СloudСonvert.API.Models.Enums;
using СloudСonvert.API.Models.ExportOperations;
using СloudСonvert.API.Models.ImportOperations;
using СloudСonvert.API.Models.JobModels;

namespace СloudСonvert.Test
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
          import_it = new ImportUploadData
          {
            Operation = ImportOperation.ImportUpload.GetEnumDescription()
          },
          export_it = new ExportUrlData
          {
            Operation = ExportOperation.ExportUrl.GetEnumDescription(),
            Input = "import_it"
          }
        },
        Tag = "integration-test-upload-download"
      };

      var job = await _cloudConvertAPI.CreateJobAsync(req);

      var uploadTask = job.Data.Tasks.FirstOrDefault(t => t.Name == "import_it");

      Assert.IsNotNull(uploadTask);

      var path = @"TestFiles\Test.pdf";
      byte[] file = await File.ReadAllBytesAsync(path);
      string fileName = "Test.pdf";

      var result = await _cloudConvertAPI.UploadAsync(uploadTask.Result.Form.Url.ToString(), file, fileName, uploadTask.Result.Form.Parameters);

      job = await _cloudConvertAPI.WaitJobAsync(job.Data.Id);

      Assert.AreEqual(job.Data.Status, "finished");

      // download export file

      var exportTask = job.Data.Tasks.FirstOrDefault(t => t.Name == "export_it");

      var fileExport = exportTask.Result.Files.FirstOrDefault();

      Assert.AreEqual(fileExport.Filename, "Test.pdf");

      using (var client = new WebClient()) client.DownloadFile(fileExport.Url, fileExport.Filename);
    }

    [Test]
    public async Task CreateTask()
    {

    }
  }
}
