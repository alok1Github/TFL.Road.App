﻿using Moq;
using TFL.API.Features.Road;
using TFL.API.Model;
using TFL.API.Request;
using TFL.Common.Interfaces;
using TFL.Common.Request;

namespace TFL.API.Tests.Features
{
    [TestClass]
    public class GetRoadDetailsTests
    {
        private GetRoadDetails _getWeather;
        private Mock<IAppSettings<RoadConfigRequest>> _mockAppSettings;
        private Mock<IAPIGetService<RoadModel>> _mockService;
        private Mock<IURI<RoadConfigRequest, RoadRequest>> _mockUrl;

        [TestInitialize]
        public void SetUp()
        {
            _mockAppSettings = new Mock<IAppSettings<RoadConfigRequest>>();
            _mockService = new Mock<IAPIGetService<RoadModel>>();
            _mockUrl = new Mock<IURI<RoadConfigRequest, RoadRequest>>();

            _getWeather = new GetRoadDetails(_mockService.Object, _mockAppSettings.Object, _mockUrl.Object); ;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Null_Exception_For_Null_AppSettingsInstance() =>
        new GetRoadDetails(_mockService.Object, null, _mockUrl.Object);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Null_Exception_For_Null_ServiceInstance() =>
       new GetRoadDetails(null, _mockAppSettings.Object, _mockUrl.Object);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Null_Exception_For_Null_UrlInstance() =>
       new GetRoadDetails(_mockService.Object, _mockAppSettings.Object, null);

        [TestMethod]
        public async Task Returns_Null_For_Null_AppSettingsValues()
        {
            var result = await _getWeather.Handler(new RoadRequest());

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Returns_Null_For_Null_Url()
        {
            _mockAppSettings.Setup(s => s.GetAppSettings())
             .Returns(Task.FromResult(new RoadConfigRequest()));

            var handler = _getWeather.Handler(new RoadRequest());

            Assert.IsNull(handler.Result);
        }

        [TestMethod]
        public async Task Returns_Null_For_Null_Response_From_Service()
        {
            _mockAppSettings.Setup(s => s.GetAppSettings())
             .Returns(Task.FromResult(new RoadConfigRequest()));

            _mockUrl.Setup(s => s.BuildUri(It.IsAny<RoadConfigRequest>(),
                It.IsAny<RoadRequest>()))
            .Returns("Test");

            var result = await _getWeather.Handler(new RoadRequest());

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task Returns_WeatherModel_For_valid_Request()
        {
            _mockAppSettings.Setup(s => s.GetAppSettings())
             .Returns(Task.FromResult(new RoadConfigRequest()));

            _mockUrl.Setup(s => s.BuildUri(It.IsAny<RoadConfigRequest>(),
                It.IsAny<RoadRequest>()))
            .Returns("Test");

            _mockService.Setup(s => s.GetData(It.IsAny<ServiceRequest>()))
          .Returns(Task.FromResult(new RoadModel()));

            var result = await _getWeather.Handler(new RoadRequest());

            Assert.IsNotNull(result);

            Assert.AreEqual(typeof(RoadModel), result.GetType());
        }

    }
}
