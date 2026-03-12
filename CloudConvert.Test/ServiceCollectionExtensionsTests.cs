using System;
using CloudConvert.API;
using CloudConvert.API.Extensions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace CloudConvert.Test
{
  [TestFixture]
  public class ServiceCollectionExtensionsTests
  {
    private ServiceProvider BuildProvider(Action<CloudConvertOptions> configure)
    {
      var services = new ServiceCollection();
      services.AddCloudConvertAPI(configure);
      return services.BuildServiceProvider();
    }

    [Test]
    public void AddCloudConvertAPI_ValidApiKey_ResolvesICloudConvertAPI()
    {
      using var provider = BuildProvider(o => o.ApiKey = "test_key");

      var api = provider.GetService<ICloudConvertAPI>();

      Assert.IsNotNull(api);
    }

    [Test]
    public void AddCloudConvertAPI_ValidApiKey_ResolvesAsCloudConvertAPI()
    {
      using var provider = BuildProvider(o => o.ApiKey = "test_key");

      var api = provider.GetService<ICloudConvertAPI>();

      Assert.IsInstanceOf<CloudConvertAPI>(api);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    public void AddCloudConvertAPI_MissingApiKey_ThrowsArgumentException(string apiKey)
    {
      Assert.Throws<ArgumentException>(() =>
          BuildProvider(o => o.ApiKey = apiKey));
    }

    [Test]
    public void AddCloudConvertAPI_RegisteredAsSingleton_ReturnsSameInstance()
    {
      using var provider = BuildProvider(o => o.ApiKey = "test_key");

      var first = provider.GetService<ICloudConvertAPI>();
      var second = provider.GetService<ICloudConvertAPI>();

      Assert.AreSame(first, second);
    }

    [Test]
    public void AddCloudConvertAPI_DefaultOptions_IsSandboxIsFalse()
    {
      var options = new CloudConvertOptions();

      Assert.IsFalse(options.IsSandbox);
    }
  }
}
