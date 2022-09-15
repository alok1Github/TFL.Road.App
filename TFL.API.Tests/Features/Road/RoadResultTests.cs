using System.Net;
using TFL.API.Features.Road;

namespace TFL.API.Tests.Features.Road
{
    [TestClass]
    public class RoadResultTests
    {
        private RoadResult _result;

        [TestInitialize]
        public void SetUp()
        {
            _result = new RoadResult();
        }

        [TestMethod]
        public async Task Throws_Null_Exception_For_Null_HttpResponse()
        {
            var result = await _result.BuildResponse(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task Returns_ValidRoadDetails_For_True_SuccessStatusCode()
        {
            HttpResponseMessage mockResponse = mockValidRoadResponse();

            var result = await _result.BuildResponse(mockResponse);

            Assert.AreEqual(result.ValidRoadDetails.Count, 1);
            Assert.AreEqual(result.ValidRoadDetails[0].DisplayName, "A2");
            Assert.AreEqual(result.ValidRoadDetails[0].Id, "a2");
            Assert.AreEqual(result.ValidRoadDetails[0].StatusSeverity, "Good");
            Assert.AreEqual(result.ValidRoadDetails[0].StatusSeverityDescription, "No Exceptional Delays");
        }

        [TestMethod]
        public async Task Returns_NullInValidRoadDetailsResponse_For_True_SuccessStatusCode()
        {
            HttpResponseMessage mockResponse = mockValidRoadResponse();

            var result = await _result.BuildResponse(mockResponse);

            Assert.IsNotNull(result);
            Assert.IsNull(result.InvalidRoadDetails);
        }

        [TestMethod]
        public async Task Returns_InvalidRoadDetails_For_False_SuccessStatusCode()
        {
            HttpResponseMessage mockResponse = mockInvalidRoadResponse();

            var result = await _result.BuildResponse(mockResponse);

            Assert.AreEqual(result.InvalidRoadDetails.ExceptionType, "EntityNotFoundException");
            Assert.AreEqual(result.InvalidRoadDetails.HttpStatus, "NotFound");
            Assert.AreEqual(result.InvalidRoadDetails.HttpStatusCode, 404);
            Assert.AreEqual(result.InvalidRoadDetails.Message, "The following road id is not recognised: A234");
        }

        [TestMethod]
        public async Task Returns_NullValidRoadDetailsResponse_For_False_SuccessStatusCode()
        {
            HttpResponseMessage mockResponse = mockInvalidRoadResponse();

            var result = await _result.BuildResponse(mockResponse);

            Assert.IsNotNull(result);
            Assert.IsNull(result.ValidRoadDetails);
        }

        private static HttpResponseMessage mockInvalidRoadResponse()
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(@"{""exceptionType"": ""EntityNotFoundException"",
                                               ""message"": ""The following road id is not recognised: A234"",
                                               ""httpStatus"": ""NotFound"",""httpStatusCode"": 404}"),
            };
        }

        private static HttpResponseMessage mockValidRoadResponse()
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"[{ ""id"": ""a2"", ""displayName"": ""A2"",
                                                ""statusSeverity"": ""Good"",""statusSeverityDescription"": ""No Exceptional Delays""}]"),
            };
        }



    }
}
