using CloudConvert.API;
using CloudConvert.API.Models.JobModels;
using CloudConvert.API.Models.TaskOperations;
using CloudConvert.API.Models.ImportOperations;
using CloudConvert.API.Models.ExportOperations;
using NUnit.Framework;


namespace CloudConvert.Test
{
  public class TestSignedUrl
  {
    const string apiKey = "";
    readonly ICloudConvertAPI _cloudConvertAPI = new CloudConvertAPI(apiKey, true);

    [Test]
    public void Sign()
    {

      string baseUrl = "https://s.cloudconvert.com/b3d85428-584e-4639-bc11-76b7dee9c109";
      string signingSecret = "NT8dpJkttEyfSk3qlRgUJtvTkx64vhyX";
      string cacheKey = "mykey";
      
      JobCreateRequest job = new JobCreateRequest
      {
        Tasks = new
        {
          import_example_1 = new ImportUploadCreateRequest(),
          convert = new ConvertCreateRequest
          {
            Input = "import_example_1",
            Input_Format = "pdf",
            Output_Format = "docx"
          },
          export = new ExportUrlCreateRequest
          {
            Input = "convert"
          }
        },
    
      };

      string signedUrl = _cloudConvertAPI.CreateSignedUrl(baseUrl, signingSecret, job, cacheKey);


      StringAssert.StartsWith(baseUrl, signedUrl);
      StringAssert.Contains("?job=", signedUrl);
      StringAssert.Contains("&cache_key=mykey", signedUrl);
      StringAssert.Contains("&s=81213540c2ccdf3330a0cf237642f14b381f57cf5bbffe293eb118468fde700b", signedUrl);
    }
  }
}
