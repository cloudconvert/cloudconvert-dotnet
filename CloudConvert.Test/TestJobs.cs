using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using CloudConvert.API;
using CloudConvert.API.Models;
using CloudConvert.API.Models.JobModels;
using Moq;
using NUnit.Framework;

namespace CloudConvert.Test
{
  public class TestJobs
  {
    readonly Mock<ICloudConvertAPI> _cloudConvertAPI = new Mock<ICloudConvertAPI>();

    [Test]
    public async Task GetAllJobs()
    {
      try
      {
        JobListFilter filter = new JobListFilter();

        var path = @"Responses/jobs.json";
        string json = File.ReadAllText(path);
        _cloudConvertAPI.Setup(cc => cc.GetAllJobsAsync(filter, default))
                        .ReturnsAsync(JsonSerializer.Deserialize<ListResponse<JobResponse>>(json, DefaultJsonSerializerOptions.SerializerOptions));

        var jobs = await _cloudConvertAPI.Object.GetAllJobsAsync(filter);

        Assert.IsNotNull(jobs);
        Assert.IsTrue(jobs.Data.Count >= 0);
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
    public async Task CreateJob()
    {
      var req = new JobCreateRequest();

      var path = AppDomain.CurrentDomain.BaseDirectory + @"Responses/job_created.json";
      string json = File.ReadAllText(path);
      _cloudConvertAPI.Setup(cc => cc.CreateJobAsync(req, default))
                      .ReturnsAsync(JsonSerializer.Deserialize<Response<JobResponse>>(json, DefaultJsonSerializerOptions.SerializerOptions));

      var job = await _cloudConvertAPI.Object.CreateJobAsync(req);

      Assert.IsNotNull(job);
      Assert.IsTrue(job.Data.Tasks.Count > 0);
      Assert.AreEqual(job.Data.Status, "waiting");
    }

    [Test]
    public async Task GetJob()
    {
      string id = "cd82535b-0614-4b23-bbba-b24ab0e892f7";

      var path = AppDomain.CurrentDomain.BaseDirectory + @"Responses/job.json";
      string json = File.ReadAllText(path);
      _cloudConvertAPI.Setup(cc => cc.GetJobAsync(id, default))
                      .ReturnsAsync(JsonSerializer.Deserialize<Response<JobResponse>>(json, DefaultJsonSerializerOptions.SerializerOptions));

      var job = await _cloudConvertAPI.Object.GetJobAsync(id);

      Assert.IsNotNull(job);
      Assert.IsTrue(job.Data.Tasks.Count > 0);
      Assert.AreEqual(job.Data.Status, "error");
    }

    [Test]
    public async Task WaitJob()
    {
      string id = "1087398b-077e-4e30-8971-1be424da232a";

      var path = AppDomain.CurrentDomain.BaseDirectory + @"Responses/job_finished.json";
      string json = File.ReadAllText(path);
      _cloudConvertAPI.Setup(cc => cc.WaitJobAsync(id, default))
                      .ReturnsAsync(JsonSerializer.Deserialize<Response<JobResponse>>(json, DefaultJsonSerializerOptions.SerializerOptions));

      var job = await _cloudConvertAPI.Object.WaitJobAsync(id);

      Assert.IsNotNull(job);
      Assert.IsTrue(job.Data.Tasks.Count > 0);
      Assert.AreEqual(job.Data.Status, "finished");
    }

    [Test]
    public async Task DeleteJob()
    {
      string id = "cd82535b-0614-4b23-bbba-b24ab0e892f7";

      _cloudConvertAPI.Setup(cc => cc.DeleteJobAsync(id, default));

      await _cloudConvertAPI.Object.DeleteJobAsync(id);
    }
  }
}
