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
    const string apiKey = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIxIiwianRpIjoiNzhlMTU1OTU2ZjQyNjU2YmU4NGJhOGExOTNiZTZkMTdlODA4MWM5MDQ5Yjk4ZDllYjIzMjFkNzgxYTNkOGNkNWYwODQ4NDFiYzRmODczOWQiLCJpYXQiOiIxNjEzNzM5NjIzLjA3NzQ1MSIsIm5iZiI6IjE2MTM3Mzk2MjMuMDc3NDU0IiwiZXhwIjoiNDc2OTQxMzIyMy4wMjA1ODUiLCJzdWIiOiIyMzAwNjM4OSIsInNjb3BlcyI6WyJ1c2VyLndyaXRlIiwidXNlci5yZWFkIiwidGFzay5yZWFkIiwidGFzay53cml0ZSIsIndlYmhvb2sucmVhZCIsIndlYmhvb2sud3JpdGUiLCJwcmVzZXQucmVhZCIsInByZXNldC53cml0ZSJdfQ.mt0E24JFoSSPPtZsham6fMzvz-cCUM_8vp5NEiq3NEvhn8SsHLBBEqug310hK63gIISEuBOqBlC0Nhc41dfsuxzQqu7cSJ86nCeTZc9IgqmgSCk2IzAnSeQeAO409f_qyKTgLeglgYUefRgfuMhDHym9fQLqbMhdYB0cyJufZZ4UoqZewwgUlMl5f4sm-mwKpIiNdIIfXVRyN4Rc1dMSfM3ZXw10YRlvBuIgEQDndnATpl3CuTy2bgw-_TjiAaPgqv2OoYWo5VCOqz3c0L4P9KulfP74mrE2FX2OY4uH9njkUFxfvBlOXIS4F-netI0gI-U4G1N68g9NKYm5mpTIg8dS7iVeOzh0bgFIGuiG56quxiIbKLG5kn8HoT3RsNCIZmHR7azPPXxekxVyqA_LTRRHWwGDXIMPEyWIAfp3GtfU-3Bn8S4imbZUpyMAWUZpDj26itJVQvFYmDM_5dhCQEZoa6eQm3g0_sFSVETAwJl1DxR8yB5HgWgQUmH82Hpn4Nq02xLZ0leyoFYP3bXFsKmtYyDsxYM-S_TkB9bCszdVmO4O753P62nl87zwEU4L0XHhwDb6tdswCBO7uUM_BoUlelmGKNS0Ew-KtOHKQpmrOZgrYWeNGMfMluf4429MlWlNhO8ceYBLakxqo5hh4cF8kbtyCwu9T6nyAJh9aFQ";
    protected ICloudConvertAPI _cloudConvertAPI;

    [OneTimeSetUp]
    public void Setup()
    {
      _cloudConvertAPI = new CloudConvertAPI(apiKey);
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

      var path = @"TestFiles\input.pdf";
      byte[] file = await File.ReadAllBytesAsync(path);
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

      var path = @"TestFiles\input.pdf";
      byte[] file = await File.ReadAllBytesAsync(path);
      string fileName = "input.pdf";

      await _cloudConvertAPI.UploadAsync(importTask.Data.Result.Form.Url.ToString(), file, fileName, importTask.Data.Result.Form.Parameters);

      importTask = await _cloudConvertAPI.WaitTaskAsync(importTask.Data.Id);

      Assert.IsNotNull(importTask);
      Assert.AreEqual(importTask.Data.Status, TaskCCStatus.finished);

      // export

      var reqExport = new ExportUrlCreateRequest
      {
        Input = importTask.Data.Id
      };

      var exportTask = await _cloudConvertAPI.CreateTaskAsync(ExportUrlCreateRequest.Operation, reqExport);

      Assert.IsNotNull(exportTask);

      exportTask = await _cloudConvertAPI.WaitTaskAsync(exportTask.Data.Id);

      Assert.IsNotNull(exportTask);
      Assert.IsTrue(exportTask.Data.Status == TaskCCStatus.finished);

      var fileExport = exportTask.Data.Result.Files.FirstOrDefault();

      Assert.IsNotNull(fileExport);
      Assert.AreEqual(fileExport.Filename, "input.pdf");

      using (var client = new WebClient()) client.DownloadFile(fileExport.Url, fileExport.Filename);

    }
  }
}
