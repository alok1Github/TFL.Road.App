using TFL.ClientApp.Features.Result;
using TFL.ClientApp.Model;

namespace TFL.ClientApp.Tests.Features.Result
{
    [TestClass]
    public class ErrorResultTests
    {
        private ErrorResult _errorResult;

        [TestInitialize]
        public void SetUp()
        {
            _errorResult = new ErrorResult();
        }

        [TestMethod]
        public void Returns_Null_Result_For_Null_ErrorModel()
        {
            var result = _errorResult.BuildResult(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Returns_Not_Null_Result_For_Valid_ErrorModel()
        {
            var result = _errorResult.BuildResult(getModel()).ToString();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Returns_Contains_Error_Details_for_Valid_ErrorModel()
        {
            var result = _errorResult.BuildResult(getModel()).ToString();

            Assert.IsTrue(result.Contains("ErrorId  : 123"));
            Assert.IsTrue(result.Contains("ErrorMessage  : Unknown Error"));
            Assert.IsTrue(result.Contains("ErrorStatusCode  : 500"));
        }

        private static ErrorModel getModel() =>
             new ErrorModel
             {
                 ErrorId = "123",
                 ErrorMessage = "Unknown Error",
                 ErrorStatusCode = 500
             };

    }
}
