using Moq;
using TFL.ClientApp.Features.Command;
using TFL.ClientApp.Features.Result;
using TFL.ClientApp.Model;
using TFL.ClientApp.Request;
using TFL.Common.Interfaces;
using TFL.Common.Request;

namespace TFL.ClientApp.Tests.Features.Command
{
    [TestClass]
    public class GetRoadStatusTests
    {
        private GetRoadStatus _getRoadStatus;
        private Mock<IAppSettings<ClientConfigRequest>> _mockAppSettings;
        private Mock<IAPIGetService<ClientModel>> _mockService;
        private Mock<IURI<ClientConfigRequest, ClientRequest>> _mockUrl;
        private Mock<IResult<ClientModel>> _mockResult;

        [TestInitialize]
        public void SetUp()
        {
            _mockAppSettings = new Mock<IAppSettings<ClientConfigRequest>>();
            _mockService = new Mock<IAPIGetService<ClientModel>>();
            _mockUrl = new Mock<IURI<ClientConfigRequest, ClientRequest>>();
            _mockResult = new Mock<IResult<ClientModel>>();

            _getRoadStatus = new GetRoadStatus(_mockService.Object, _mockAppSettings.Object,
                                               _mockUrl.Object, _mockResult.Object); ;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Null_Exception_For_Null_AppSettingsInstance() =>
      new GetRoadStatus(_mockService.Object, null, _mockUrl.Object, _mockResult.Object);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Null_Exception_For_Null_ServiceInstance() =>
       new GetRoadStatus(null, _mockAppSettings.Object, _mockUrl.Object, _mockResult.Object);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Null_Exception_For_Null_UrlInstance() =>
       new GetRoadStatus(_mockService.Object, _mockAppSettings.Object, null, _mockResult.Object);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Null_Exception_For_Null_ResultInstance() =>
      new GetRoadStatus(_mockService.Object, _mockAppSettings.Object, _mockUrl.Object, null);


        [TestMethod]

        public async Task Returns_Null_For_Null_AppSettingsValues() => await AssertNoException();

        [TestMethod]
        public async Task Returns_Null_For_Null_Response_From_UrlBuilder()
        {
            _mockAppSettings.Setup(s => s.GetAppSettings())
             .Returns(Task.FromResult(new ClientConfigRequest()));

            await AssertNoException();
        }

        [TestMethod]
        public async Task Returns_Null_For_Null_Response_From_Service()
        {
            _mockAppSettings.Setup(s => s.GetAppSettings())
             .Returns(Task.FromResult(new ClientConfigRequest()));

            _mockUrl.Setup(s => s.BuildUri(It.IsAny<ClientConfigRequest>(),
                It.IsAny<ClientRequest>()))
            .Returns("Test");

            await AssertNoException();
        }

        [TestMethod]
        public async Task Returns_ClientModel_For_valid_Request()
        {
            _mockAppSettings.Setup(s => s.GetAppSettings())
             .Returns(Task.FromResult(new ClientConfigRequest()));

            _mockUrl.Setup(s => s.BuildUri(It.IsAny<ClientConfigRequest>(),
                It.IsAny<ClientRequest>()))
            .Returns("Test");

            _mockService.Setup(s => s.GetData(It.IsAny<ServiceRequest>()))
          .Returns(Task.FromResult(new ClientModel()));

            await AssertNoException();
        }

        private async Task AssertNoException()
        {
            try
            {
                await _getRoadStatus.OnAction("A2");
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
    }
}
