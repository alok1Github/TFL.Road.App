using TFL.API.Builder;
using TFL.API.Request;

namespace TFL.API.Tests.Features
{
    [TestClass]
    public class RoadURIBuilderTests
    {
        private RoadURIBuilder _uriBuilder;

        [TestInitialize]
        public void SetUp()
        {
            _uriBuilder = new RoadURIBuilder();
        }

        [TestMethod]
        public void Returns_Null_For_null_ConfigSettingsInstance()
        {
            var result = _uriBuilder.BuildUri(null, new RoadRequest());

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Returns_Null_For_null_RequesObject()
        {
            var result = _uriBuilder.BuildUri(new RoadConfigRequest(), null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Throws_Null_Exception_For_Null_Dependencies()
        {
            var settings = new RoadConfigRequest();
            settings.BaseUrl = "https://api.tfl.gov.uk/Road/";
            settings.Key = "7b662d8e60624c2b9b2ccaedaba91cd5";
            settings.AppId = "TFL.App";

            var param = new RoadRequest();
            param.Id = "A2";

            var expectedUri = "https://api.tfl.gov.uk/Road/A2?app_key=7b662d8e60624c2b9b2ccaedaba91cd5&app_id=TFL.App";

            var result = _uriBuilder.BuildUri(settings, param);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, expectedUri);
        }
    }
}
