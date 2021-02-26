using System;
using System.IO;
using System.Threading.Tasks;
using CloudConvert.API;
using CloudConvert.API.Models;
using CloudConvert.API.Models.JobModels;
using Moq;
using Newtonsoft.Json;
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
        JobFilter filter = new JobFilter();

        var path = @"Responses\jobs.json";
        string json = File.ReadAllText(path);
        _cloudConvertAPI.Setup(cc => cc.GetAllJobsAsync(filter))
                        .ReturnsAsync(JsonConvert.DeserializeObject<JobsResponse>(json));

        var jobs = await _cloudConvertAPI.Object.GetAllJobsAsync(filter);

        Assert.IsNotNull(jobs);
        Assert.IsTrue(jobs.Data.Count >= 0);
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
      var req = new JobCreateRequest();

      var path = @"Responses\job_created.json";
      string json = File.ReadAllText(path);
      _cloudConvertAPI.Setup(cc => cc.CreateJobAsync(req))
                      .ReturnsAsync(JsonConvert.DeserializeObject<JobResponse>(json));

      var job = await _cloudConvertAPI.Object.CreateJobAsync(req);

      Assert.IsNotNull(job);
      Assert.IsTrue(job.Data.Tasks.Count > 0);
      Assert.AreEqual(job.Data.Status, "waiting");
    }

    [Test]
    public async Task GetJob()
    {
      string id = "cd82535b-0614-4b23-bbba-b24ab0e892f7";

      var path = @"Responses\job.json";
      string json = File.ReadAllText(path);
      _cloudConvertAPI.Setup(cc => cc.GetJobAsync(id))
                      .ReturnsAsync(JsonConvert.DeserializeObject<JobResponse>(json));

      var job = await _cloudConvertAPI.Object.GetJobAsync(id);

      Assert.IsNotNull(job);
      Assert.IsTrue(job.Data.Tasks.Count > 0);
      Assert.AreEqual(job.Data.Status, "error");
    }

    [Test]
    public async Task WaitJob()
    {
      string id = "1087398b-077e-4e30-8971-1be424da232a";

      var path = @"Responses\job_finished.json";
      string json = File.ReadAllText(path);
      _cloudConvertAPI.Setup(cc => cc.WaitJobAsync(id))
                      .ReturnsAsync(JsonConvert.DeserializeObject<JobResponse>(json));

      var job = await _cloudConvertAPI.Object.WaitJobAsync(id);

      Assert.IsNotNull(job);
      Assert.IsTrue(job.Data.Tasks.Count > 0);
      Assert.AreEqual(job.Data.Status, "finished");
    }

    [Test]
    public async Task DeleteJob()
    {
      string id = "cd82535b-0614-4b23-bbba-b24ab0e892f7";

      _cloudConvertAPI.Setup(cc => cc.DeleteJobAsync(id));

      await _cloudConvertAPI.Object.DeleteJobAsync(id);
    }

  }
}
