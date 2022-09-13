using TFL.API.Features.Road;
using TFL.API.Request;

namespace TFL.API.Tests.Features.Road
{
    [TestClass]
    public class RoadAppSettingTests
    {
        private RoadAppSetting _configSettings;
        [TestInitialize]
        public void SetUp()
        {
            _configSettings = new RoadAppSetting();
        }

        [TestMethod]
        public async Task Returns_RoadConfigRequest_Object_From_AppSettings()
        {
            var result = await _configSettings.GetAppSettings();

            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(RoadConfigRequest), result.GetType());
        }

        [TestMethod]
        public async Task Returns_BaseUrl_Object_From_AppSettings()
        {
            var result = await _configSettings.GetAppSettings();

            Assert.AreEqual(result.BaseUrl, "https://api.tfl.gov.uk/Road/");

            // TO Do : Key and App_Id could be asserted as well.
        }
    }
}
