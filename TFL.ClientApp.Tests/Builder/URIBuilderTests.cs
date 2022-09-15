using TFL.ClientApp.Builder;
using TFL.ClientApp.Request;

namespace TFL.ClientApp.Tests.Builder
{
    [TestClass]
    public class URIBuilderTests
    {
        private URIBuilder _uriBuilder;

        [TestInitialize]
        public void SetUp()
        {
            _uriBuilder = new URIBuilder();
        }

        [TestMethod]
        public void Returns_Null_For_null_ConfigSettingsInstance()
        {
            var result = _uriBuilder.BuildUri(null, new ClientRequest());

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Returns_Null_For_null_RequesObject()
        {
            var result = _uriBuilder.BuildUri(new ClientConfigRequest(), null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Returns_ExpectedUri_For_Valid_Request()
        {
            var settings = new ClientConfigRequest();
            settings.BaseUrl = "https://localhost:7111/api/Road?"; ;

            var param = new ClientRequest();
            param.RoadName = "A2";

            var expectedUri = "https://localhost:7111/api/Road?id=A2";

            var result = _uriBuilder.BuildUri(settings, param);

            Assert.IsNotNull(result);
            Assert.AreEqual(result, expectedUri);
        }
    }
}
