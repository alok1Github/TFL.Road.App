using Moq;
using System.Text;
using TFL.ClientApp.Features.Result;
using TFL.ClientApp.Model;

namespace TFL.ClientApp.Tests.Features.Result
{
    [TestClass]
    public class ResultHandlerTests
    {
        private ResultHandler _handler;

        private Mock<IResult<ClientResult>> _mockValidResult;
        private Mock<IResult<ClientModel>> _mockinvalidResult;

        [TestInitialize]
        public void SetUp()
        {
            _mockValidResult = new Mock<IResult<ClientResult>>();
            _mockinvalidResult = new Mock<IResult<ClientModel>>();

            _handler = new ResultHandler(_mockValidResult.Object, _mockinvalidResult.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Null_Exception_For_Null_ValidRoad_Instance() =>
            new ResultHandler(null, _mockinvalidResult.Object);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throws_Null_Exception_For_Null_InValidRoad_Instance() =>
            new ResultHandler(_mockValidResult.Object, null);

        [TestMethod]
        public void Returns_Default_Result_For_Null_Model()
        {
            var result = _handler.BuildResult(null).ToString();

            Assert.AreEqual(result, "Road information are missing");
        }

        [TestMethod]
        public void Returns_Result_For_Invalid_Road_If_Road_Is_Not_Valid()
        {
            var model = new ClientModel();
            model.ValidRoadDetails = null;

            _mockinvalidResult.Setup(s => s.BuildResult(It.IsAny<ClientModel>()))
                .Returns(new StringBuilder("Result Invalid"));


            var result = _handler.BuildResult(model).ToString();

            Assert.IsNotNull(result);

            Assert.AreEqual(result, "Result Invalid");
        }

        [TestMethod]
        public void Returns_Valid_Road_Result_For_Valid_Model()
        {
            var model = new ClientModel();
            model.ValidRoadDetails = new List<ClientResult>();
            model.ValidRoadDetails.Add(new ClientResult());

            _mockValidResult.Setup(s => s.BuildResult(It.IsAny<ClientResult>()))
           .Returns(new StringBuilder("Valid Result"));

            var result = _handler.BuildResult(model);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Returns_Default_Result_If_Invalid_Road_and_Valid_Road_Result_Are_Null()
        {
            var model = new ClientModel();
            model.ValidRoadDetails = null;

            var result = _handler.BuildResult(model).ToString();

            Assert.IsNotNull(result);

            Assert.AreEqual(result, "Road information are missing");
        }

    }
}
