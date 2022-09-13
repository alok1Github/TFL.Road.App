using Microsoft.AspNetCore.Http;
using TFL.API.ExceptionHandlers;

namespace TFL.API.Tests.ExceptionHandlers
{
    [TestClass]
    public class ExceptionResponseBuilderTests
    {
        [TestMethod]
        public void Returns_Exception_Message_If__Available_In_Exception()
        {
            var model = ExceptionResponseBuilder.createRespone(new Exception(), new DefaultHttpContext());

            Assert.IsNotNull(model);
            Assert.AreEqual(model.ErrorMessage.Trim(), "Exception of type 'System.Exception' was thrown.".Trim());
        }

        [TestMethod]
        public void Returns_Null_Message_If_No_Message_In_Exception()
        {
            var model = ExceptionResponseBuilder.createRespone(null, new DefaultHttpContext());

            Assert.IsNotNull(model);
            Assert.IsNull(model.ErrorMessage);
        }

        [TestMethod]
        public void Returns_Custom_Message_If_Custom_Message_In_Exception()
        {
            var model = ExceptionResponseBuilder.createRespone(null, new DefaultHttpContext(), "Unknown Error");

            Assert.IsNotNull(model);
            Assert.AreEqual(model.ErrorMessage.Trim(), "Unknown Error".Trim());
        }
    }
}
