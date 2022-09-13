using TFL.ClientApp.Builder;
using TFL.ClientApp.Request;

namespace TFL.ClientApp.Tests.Builder
{
    [TestClass]
    public class AppSettingBuilderTests
    {
        private AppSettingBuilder _configSettings;

        [TestInitialize]
        public void SetUp()
        {
            _configSettings = new AppSettingBuilder();
        }

        [TestMethod]
        public async Task Returns_RoadConfigRequest_Object_From_AppSettings()
        {
            var result = await _configSettings.GetAppSettings();

            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(ClientConfigRequest), result.GetType());
        }

        [TestMethod]
        public async Task Returns_BaseUrl_Object_From_AppSettings()
        {
            var result = await _configSettings.GetAppSettings();

            Assert.AreEqual(result.BaseUrl, "https://localhost:7111/api/Road?");
        }
    }
}
