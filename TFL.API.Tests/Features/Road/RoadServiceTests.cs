using Moq;
using Moq.Protected;
using TFL.API.Features.Road;
using TFL.API.Model;
using TFL.Common.Request;

namespace TFL.API.Tests.Features.Road
{
    [TestClass]
    public class RoadServiceTests
    {

        private RoadService _service;
        private HttpClient _httpClient;
        private Mock<IResult> _mockResult;
        private Mock<HttpMessageHandler> _handlerMock;

        [TestInitialize]
        public void SetUp()
        {
            _mockResult = new Mock<IResult>();
            _handlerMock = new Mock<HttpMessageHandler>();

            _handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(Helper.MockValidRoadResponse());

            _httpClient = new HttpClient(_handlerMock.Object);

            _service = new RoadService(_httpClient, _mockResult.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Null_Exception_For_Null_HttpClient() => new RoadService(null, _mockResult.Object);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Null_Exception_For_Null_ResultObject() => new RoadService(_httpClient, null);

        [TestMethod]
        public async Task Returns_Null_For_null_ServiceRequest()
        {
            var result = await _service.GetData(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task Returns_RoadModel_Object_For_ValidResponse_From_API()
        {
            _mockResult.Setup(s => s.BuildResponse(It.IsAny<HttpResponseMessage>()))
            .Returns(Task.FromResult(new RoadModel()));

            var result = await _service.GetData(new ServiceRequest { Uri = "https://api.tfl.gov.uk/Road/" });

            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(RoadModel), result.GetType());
        }

        [TestMethod]
        public async Task Returns_ValidRoad_Response_Object_ValidRaod_null_RequesObject()
        {
            _mockResult.Setup(s => s.BuildResponse(It.IsAny<HttpResponseMessage>()))
            .Returns(Task.FromResult(new RoadModel()));

            var result = await _service.GetData(new ServiceRequest { Uri = "https://api.tfl.gov.uk/Road/" });

            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(RoadModel), result.GetType());
        }
    }
}

