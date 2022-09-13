using Microsoft.AspNetCore.Mvc;
using Moq;
using TFL.API.Features.Road;
using TFL.API.Interfaces;
using TFL.API.Model;
using TFL.API.Request;

namespace TFL.API.Tests.Features.Road
{
    [TestClass]
    public class RoadControllerTests
    {
        private RoadController _controller;
        private Mock<IGet<RoadRequest, RoadModel>> _mockGet;

        [TestInitialize]
        public void SetUp()
        {
            _mockGet = new Mock<IGet<RoadRequest, RoadModel>>();
            _controller = new RoadController(_mockGet.Object);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Null_Exception_For_Null_Dependencies() =>
        new RoadController(null);

        [TestMethod]
        public async Task Returns_BadRequestResult_For_Null_Request()
        {
            var result = await _controller.Get(null);

            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(BadRequestResult), result.GetType());
        }

        [TestMethod]
        public async Task Returns_NotFoundResult_For_NullResponse_FromHandler()
        {
            var result = await _controller.Get(new RoadRequest());

            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(NotFoundResult), result.GetType());
        }

        [TestMethod]
        public async Task Returns_OkResult_For_ValidRequest_FromHandler()
        {
            _mockGet.Setup(s => s.Handler(It.IsAny<RoadRequest>()))
               .Returns(Task.FromResult(new RoadModel()));

            var result = await _controller.Get(new RoadRequest());

            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(OkObjectResult), result.GetType());
        }
    }
}
