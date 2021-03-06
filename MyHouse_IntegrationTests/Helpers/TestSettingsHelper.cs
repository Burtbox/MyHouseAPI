using System.IO;
using MyHouseIntegrationTests.Shared;
using Newtonsoft.Json;

namespace MyHouseIntegrationTests.Helpers
{
    public static class TestSettingsHelper
    {
        public static TestSettings TestSettings => JsonConvert.DeserializeObject<TestSettings>(File.ReadAllText(@"..//..//..//testsettings.json"));
    }
}