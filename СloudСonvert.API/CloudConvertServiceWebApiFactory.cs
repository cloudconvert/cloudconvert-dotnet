using Refit;

namespace СloudСonvert.API
{
  public static class CloudConvertServiceWebApiFactory
  {
    public static ICloudConvertServiceWebApi CreateWebApi(string serverUrl)
    {
      return RestService.For<ICloudConvertServiceWebApi>(serverUrl, new RefitSettings
      {
        HttpMessageHandlerFactory = () => new WebApiHandler(loggingEnabled: true),
        ContentSerializer = new NewtonsoftJsonContentSerializer()
      });
    }
  }
}
