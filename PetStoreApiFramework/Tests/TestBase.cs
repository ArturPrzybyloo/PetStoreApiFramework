using NUnit.Framework;
using PetStoreApiFramework.Configuration;
using RestSharp;

namespace PetStoreApiFramework.Tests
{
    public class TestBase
    {
        public RestClient client;

        [OneTimeSetUp]
        public void SetUp()
        {
            ConfigProvider.LoadConfiguration();
        }
    }
}
