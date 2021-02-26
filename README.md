# cloudconvert-net

> This is the official .net SDK v1 for the [CloudConvert](https://cloudconvert.com/api/v2) _API v2_.

## Installation

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
```

You can use the [CloudConvert Job Builder](https://cloudconvert.com/api/v2/jobs/builder) to see the available options for the various task types.

## Downloading Files

CloudConvert can generate public URLs for using `export/url` tasks. You can use these URLs to download output files.


## Uploading Files

Uploads to CloudConvert are done via `import/upload` tasks (see the [docs](https://cloudconvert.com/api/v2/import#import-upload-tasks)). This SDK offers a convenient upload method:


## Webhook Signing

The .net SDK allows to verify webhook requests received from CloudConvert.


## Using Sandbox

You can use the Sandbox to avoid consuming your quota while testing your application. The .net SDK allows you to do that.


## Contributing

This section is intended for people who want to contribute to the development of this library.

### Unit Tests

### Integration Tests

## Resources

-   [API v2 Documentation](https://cloudconvert.com/api/v2)
-   [CloudConvert Blog](https://cloudconvert.com/blog)