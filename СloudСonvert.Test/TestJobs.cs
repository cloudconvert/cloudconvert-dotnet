using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using СloudСonvert.API;
using СloudСonvert.API.Models;
using СloudСonvert.API.Models.ExportOperations;
using СloudСonvert.API.Models.ImportOperations;
using СloudСonvert.API.Models.JobModels;
using СloudСonvert.API.Models.TaskOperations;

namespace СloudСonvert.Test
{
  public class TestJobs
  {
    const string apiKey = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIxIiwianRpIjoiMDM5MGQ3Njk4N2I3NzY1YjMyZTJhMTRjYjIzOTUzYTc0YzNmMTEyOWY5MzU5M2E5ODdhZjUxM2YzYWY5YmZjNzU1YjZkMTUzMjMwM2Y5MjEiLCJpYXQiOjE2MTM3NDAzNTAsIm5iZiI6MTYxMzc0MDM1MCwiZXhwIjo0NzY5NDEzOTUwLCJzdWIiOiIyMzAwNjM4OSIsInNjb3BlcyI6WyJ1c2VyLnJlYWQiLCJ1c2VyLndyaXRlIiwidGFzay5yZWFkIiwidGFzay53cml0ZSIsIndlYmhvb2sucmVhZCIsIndlYmhvb2sud3JpdGUiLCJwcmVzZXQucmVhZCIsInByZXNldC53cml0ZSJdfQ.A-mMEGul6IEPUUkga7iTnjBrcSZnPNfLVOiN7CRLK29jOaZBL0eIuZtsao8E9uUqqgoXy1KLDUelh5WyzsO4w34KYQojgVJsZKEU86QCbVsJQXXnaSXbXPoTlyugnHdEKqnncBNqgbSbKMOOZhiglXLRk7IXAOl8ai4PmaW9_yymqlz4NH95RtM7CDIm5Ej1i4u517-1fdd3QQKeJAYLVi_Xt_vgfWYATf0JIT_2r2ED1-sk2DWALtonvFiR-HRZX7SltftWWWct9OjxcGigC45hxLke3Ln-VhthySIebo48hbE89UYWCkh8ElzRT2UpVNE1S7LNYJxfAimjh2DZpfyJALVQNJXUrbMLDWJeDJDAgcKyzeElllioxxTY2K-wmDi2HiVzB-j6qMgAoueAfhyshoTtUouLGpZeX51GWv6kr74Fn31WYihevlDDrpkmgNfCKkVPt__tx6SI5Qh-cvGLgwT-x1QK0jQxeSjXm1N6NLH4jDN0qh88eWDrG1KsRqRwKRtWOnWRYTEehUgoEkmRBG8bXPB6MuFRaoWiav-tZ41kxya8jORWGAYoUuMbtKJS8WxzTYEV8ipnQo8sLHI7Jt27TMZAHZTBSYsOQUY9aUxN6f40eXdUY7Uw33zNCam-vUcTvZ46cwdCdlI3KRjXXoM6_cFS1RUhDEZWcr4";
    readonly ICloudConvertAPI _cloudConvertAPI = new CloudConvertAPI(apiKey, true);

    [Test]
    public async Task GetAllJobs()
    {
      try
      {
        JobFilter filter = new JobFilter();
        var result = await _cloudConvertAPI.GetAllJobsAsync(filter);

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
    public async Task CreateJob()
    {
      var job = await _cloudConvertAPI.CreateJobAsync(new JobCreateRequest
      {
        Tasks = new
        {
          import_example_1 = new ImportUploadData(),
          convert = new TaskConvertCreateData
          {
            Input = "import_example_1",
            Input_Format = "pdf",
            Output_Format = "docx",
            Engine = "bcl"
          },
          export = new ExportUrlData
          {
            Input = "convert",
            Inline_Additional = true,
            Archive_Multiple_Files = true
          }
        },
        Tag = "Test"
      });

      Assert.IsNotNull(job);
      Assert.IsTrue(job.Data.Tasks.Count > 0);
      Assert.AreEqual(job.Data.Status, "waiting");
    }

    [Test]
    public async Task GetJob()
    {
      var result = await _cloudConvertAPI.GetJobAsync("e1b61f3a-a97f-43c7-b464-13209c87e89c");

      Assert.IsNotNull(result);
      Assert.IsTrue(result.Data.Tasks.Count > 0);
      Assert.AreEqual(result.Data.Status, "waiting");
    }

    [Test]
    public async Task WaitJob()
    {
      var result = await _cloudConvertAPI.WaitJobAsync("e1b61f3a-a97f-43c7-b464-13209c87e89c");

      Assert.IsNotNull(result);
      Assert.IsTrue(result.Data.Tasks.Count > 0);
      Assert.AreEqual(result.Data.Status, "finished");
    }

    [Test]
    public async Task DeleteJob()
    {
      await _cloudConvertAPI.DeleteJobAsync("2fa09cc7-3765-4b3d-8d05-da5341de1852");
    }

  }
}
