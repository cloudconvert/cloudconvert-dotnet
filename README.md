# cloudconvert-dotnet

[![.NET Tests](https://github.com/cloudconvert/cloudconvert-dotnet/actions/workflows/dotnet-tests.yml/badge.svg)](https://github.com/cloudconvert/cloudconvert-dotnet/actions/workflows/dotnet-tests.yml)
[![Nuget](https://img.shields.io/nuget/v/CloudConvert.API)](https://www.nuget.org/packages/CloudConvert.API)

This is the official .net SDK v1 for the [CloudConvert](https://cloudconvert.com/api/v2) _API v2_.

## Installation

```
PM> Install-Package CloudConvert.API
```
or
```
dotnet add package CloudConvert.API
```

## Creating Jobs

```c#
using CloudConvert.API;
using CloudConvert.API.Models.ExportOperations;
using CloudConvert.API.Models.ImportOperations;
using CloudConvert.API.Models.JobModels;
using CloudConvert.API.Models.TaskOperations;

var _cloudConvert = new CloudConvertAPI("api_key");

var job = await _cloudConvert.CreateJobAsync(new JobCreateRequest
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
            Input = "convert",
            Archive_Multiple_Files = true
          }
        },
        Tag = "Test"
      });
```

You can use the [CloudConvert Job Builder](https://cloudconvert.com/api/v2/jobs/builder) to see the available options for the various task types.

## Downloading Files

CloudConvert can generate public URLs for using `export/url` tasks. You can use these URLs to download output files.

```c#
var job = await _cloudConvertAPI.WaitJobAsync(job.Data.Id); // Wait for job completion

// download export file

var exportTask = job.Data.Tasks.FirstOrDefault(t => t.Name == "export_it");

var fileExport = exportTask.Result.Files.FirstOrDefault();

using (var client = new WebClient()) client.DownloadFile(fileExport.Url, fileExport.Filename);
```

## Uploading Files
Uploads to CloudConvert are done via `import/upload` tasks (see the [docs](https://cloudconvert.com/api/v2/import#import-upload-tasks)). This SDK offers a convenient upload method.

First create the upload job with `CreateJobAsync`:

```c#
var job = await _cloudConvertAPI.CreateJobAsync(new JobCreateRequest
      {
            Tasks = new
            {
            upload_my_file = new ImportUploadCreateRequest()
            // ...
            }
      });

var uploadTask = job.Data.Tasks.FirstOrDefault(t => t.Name == "upload_my_file");
```

Then upload the file the file with `UploadAsync`. This can be done two ways:

1. **Upload using a Stream**  
   The file will be opened and send in chunks to CloudConvert.

   > **Note**
   > The stream will not be disposed. Make sure to dispose the stream with `stream.Dispose()` or by using the [using-statement](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-statement) as shown in the following example.
   ```cs
   string path = @"TestFiles/test.pdf";
   string fileName = "test.pdf";
   
   using (System.IO.Stream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
   {
         await _cloudConvertAPI.UploadAsync(uploadTask.Result.Form.Url.ToString(), stream, fileName, uploadTask.Result.Form.Parameters);
   }
   ```
   
2. **Upload using a byte-array (`byte[]`)**  
   The entire file will be load into memory and send to CloudConvert. 
   ```cs
   string path = @"TestFiles/test.pdf";
   byte[] file = await File.ReadAllBytesAsync(path);
   string fileName = "test.pdf";
   
   await _cloudConvertAPI.UploadAsync(uploadTask.Result.Form.Url.ToString(), file, fileName, uploadTask.Result.Form.Parameters);
   ```

## Conversion Specific Options

You can pass any custom options to the task payload via the special `Options` property:

```c#
var task = new ConvertCreateRequest
          {
            Input = "import_example_1",
            Input_Format = "pdf",
            Output_Format = "jpg",
            Options = new Dictionary<string, object> {
              { "width": 800 },
              { "height": 600 },
              { "fit": "max" }
            }
          }
```
You can use the [Job Builder](https://cloudconvert.com/api/v2/jobs/builder) to see the available options.

## Webhook Signing

The .net SDK allows to verify webhook requests received from CloudConvert.

```c#
var payloadString = "..."; // The JSON string from the raw request body.
var signature = "..."; // The value of the "CloudConvert-Signature" header.
var signingSecret = "..."; // You can find it in your webhook settings.

var isValid = _cloudConvertAPI.ValidateWebhookSignatures(payloadString, signature, signingSecret);
// returns true or false
```

## Signed URLs

Signed URLs allow converting files on demand only using URL query parameters. The .NET SDK allows to generate such URLs. Therefore, you need to obtain a signed URL base and a signing secret on the [CloudConvert Dashboard](https://cloudconvert.com/dashboard/api/v2/signed-urls).

```c#
var signedUrlBase = 'https://s.cloudconvert.com/...'; // You can find it in your signed URL settings.
var signingSecret = '...'; // You can find it in your signed URL settings.
var cacheKey = 'cache-key'; // Allows caching of the result file for 24h

var job = new JobCreateRequest
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

string signedUrl = _cloudConvertAPI.CreateSignedUrl(baseUrl, signingSecret, job, cacheKey)
// returns the signed URL
```

## Using the Sandbox

You can use the Sandbox to avoid consuming your quota while testing your application. The .net SDK allows you to do that.

```c#
// Pass `true` to the constructor
var _cloudConvert = new CloudConvertAPI("api_key", true);
```

## Tests

```
dotnet test
```

### Integration Tests

By default, this runs the integration tests against the Sandbox API with an official CloudConvert account. If you would like to use your own account, you can set your API key. In this case you need to whitelist the following MD5 hashes for Sandbox API (using the CloudConvert dashboard).

    53d6fe6b688c31c565907c81de625046  input.pdf
    99d4c165f77af02015aa647770286cf9  input.png

## Resources

-   [API v2 Documentation](https://cloudconvert.com/api/v2)
-   [CloudConvert Blog](https://cloudconvert.com/blog)
