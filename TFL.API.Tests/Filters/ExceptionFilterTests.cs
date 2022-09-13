using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TFL.API.filters;

namespace TFL.API.Tests.Filters
{
    [TestClass]
    public class ExceptionFilterTests
    {
        private ExceptionFilter _filter;
        private ExceptionContext _exceptionContext;

        [TestInitialize]
        public void SetUp()
        {
            _filter = new ExceptionFilter();

            Helper.ActionContext();
            _exceptionContext = new ExceptionContext(Helper.ActionExecutingContext(), new List<IFilterMetadata>())
            {
                Exception = new Exception()
            };
        }

        [TestMethod]
        public void Returns_Status_Code_500_OnException()
        {
            _filter.OnException(_exceptionContext);

            Assert.AreEqual(_exceptionContext.HttpContext.Response.StatusCode, 500);
        }

        [TestMethod]
        public void Returns_Result_Type_JsonResult_OnException()
        {
            _filter.OnException(_exceptionContext);

            Assert.AreEqual(typeof(JsonResult), _exceptionContext.Result.GetType());
        }
    }
}
