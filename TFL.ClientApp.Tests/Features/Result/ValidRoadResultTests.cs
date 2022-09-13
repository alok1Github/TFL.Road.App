using TFL.ClientApp.Features.Result;
using TFL.ClientApp.Model;

namespace TFL.ClientApp.Tests.Features.Result
{
    [TestClass]
    public class ValidRoadResultTests
    {
        private ValidRoadResult _validResult;

        [TestInitialize]
        public void SetUp()
        {
            _validResult = new ValidRoadResult();
        }

        [TestMethod]
        public void Returns_Null_Result_For_Null_Model()
        {
            var result = _validResult.BuildResult(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Returns_Not_Null_Result_For_Valid_Model()
        {
            var result = _validResult.BuildResult(getModel()).ToString();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Returns_Contains_Error_Details_for_Valid_ErrorModel()
        {
            var result = _validResult.BuildResult(getModel()).ToString();

            Assert.IsTrue(result.Contains("Road Status is : Good"));
            Assert.IsTrue(result.Contains("Road Status Description is  : No Exceptional Delays"));
        }

        private static ClientResult getModel() =>
            new ClientResult
            {
                Id = "a2",
                DisplayName = "A2",
                StatusSeverity = "Good",
                StatusSeverityDescription = "No Exceptional Delays"
            };

    }
}
