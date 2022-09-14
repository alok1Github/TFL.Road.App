using Moq;
using TFL.ClientApp.Features.Result;
using TFL.ClientApp.Model;

namespace TFL.ClientApp.Tests.Features.Result
{
    [TestClass]
    public class InInvalidRoadResultTests
    {
        private InvalidRoadResult _InvalidRoadResult;
        private Mock<IResult<ErrorModel>> _mockErrorResult;

        [TestInitialize]
        public void SetUp()
        {
            _mockErrorResult = new Mock<IResult<ErrorModel>>();
            _InvalidRoadResult = new InvalidRoadResult(_mockErrorResult.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Null_Exception_For_Null_ErrorResult_Instance() => new InvalidRoadResult(null);

        [TestMethod]
        public void Returns_Null_Result_For_Null_Model()
        {
            var result = _InvalidRoadResult.BuildResult(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Returns_Not_Null_Result_For_Valid_Model()
        {
            var result = _InvalidRoadResult.BuildResult(getModel()).ToString();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Returns_Contains_Invalid_Road_Details_for_Valid_Model()
        {
            var result = _InvalidRoadResult.BuildResult(getModel()).ToString();

            Assert.IsTrue(result.Contains("ExceptionType type is  : EntityNotFoundException"));
            Assert.IsTrue(result.Contains("HttpStatusCode is  : 404"));
            Assert.IsTrue(result.Contains("HttpStatus is  : NotFound"));
        }

        private static ClientModel getModel() =>
            new ClientModel
            {
                ValidRoadDetails = new List<ClientResult>(),
                InvalidRoadDetails = new InvaildResult
                {
                    ExceptionType = "EntityNotFoundException",
                    HttpStatus = "NotFound",
                    HttpStatusCode = 404,
                    Message = "The following road id is not recognised: A233"
                }

            };

    }
}
