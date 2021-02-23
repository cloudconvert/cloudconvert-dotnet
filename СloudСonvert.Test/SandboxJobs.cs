using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using Refit;
using СloudСonvert.API;
using СloudСonvert.API.Extensions;
using СloudСonvert.API.Models;
using СloudСonvert.API.Models.Enums;
using СloudСonvert.API.Models.ExportOperations;
using СloudСonvert.API.Models.ImportOperations;
using СloudСonvert.API.Models.JobModels;
using СloudСonvert.API.Models.TaskOperations;

namespace СloudСonvert.Test
{
  public class SandboxJobs
  {
    const string sandboxUrlApi = "https://api.sandbox.cloudconvert.com/v2/";
    const string apiKey = "";

    [Test]
    public async Task GetAllJobs()
    {
      CloudConvertAPI ccAPI = new CloudConvertAPI(sandboxUrlApi, apiKey);
      try
      {
        JobFilter filter = new JobFilter();
        var result = await ccAPI.GetAllJobsAsync(filter);
      }
      catch (WebApiException ex)
      {
      }
      catch (ApiException ex)
      {
        if (ex.Content != null)
        {
          var error = JsonConvert.DeserializeObject<ErrorResponse>(ex.Content);
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
      CloudConvertAPI ccAPI = new CloudConvertAPI(sandboxUrlApi, apiKey);

      var req = new JobCreateRequest
      {
        Tasks = new
        {
          import_example_1 = new ImportUploadData
          {
            Operation = ImportOperation.ImportUpload.GetEnumDescription()
          },
          convert = new TaskConvertData
          {
            Operation = TaskOperation.Convert.GetEnumDescription(),
            Input = "import_example_1",
            Input_Format = "pdf",
            Output_Format = "docx",
            Page_Range = "1-2",
            Optimize_Print = true,
            Engine = "bcl"
          },
          export = new ExportUrlData
          {
            Operation = ExportOperation.ExportUrl.GetEnumDescription(),
            Input = "convert",
            Inline_Additional = true,
            Archive_Multiple_Files = true
          }
        },
        Tag = "Test"
      };

      var result = await ccAPI.CreateJobAsync(req);
    }

    [Test]
    public async Task GetJob()
    {
      CloudConvertAPI ccAPI = new CloudConvertAPI(sandboxUrlApi, apiKey);

      var result = await ccAPI.GetJobAsync("5b5a6eed-1be3-4179-8f3c-8600b6835881");
    }

    [Test]
    public async Task WaitJob()
    {
      CloudConvertAPI ccAPI = new CloudConvertAPI(sandboxUrlApi, apiKey);

      var result = await ccAPI.WaitJobAsync("5b5a6eed-1be3-4179-8f3c-8600b6835881");
    }

    [Test]
    public async Task DeleteJob()
    {
      CloudConvertAPI ccAPI = new CloudConvertAPI(sandboxUrlApi, apiKey);

      await ccAPI.DeleteJobAsync("2d1224e3-aeb1-4b90-8639-d422b6a0b61a");
    }

  }
}
