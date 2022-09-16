using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Moq;
using System.Net;

namespace TFL.API.Tests
{
    public static class Helper
    {
        public static ActionContext ActionContext() =>
           new ActionContext(
                   httpContext: new DefaultHttpContext(),
                   routeData: new RouteData(),
                   actionDescriptor: new ActionDescriptor(),
                   modelState: new ModelStateDictionary());

        public static ActionExecutingContext ActionExecutingContext() =>
           new ActionExecutingContext(ActionContext(), new List<IFilterMetadata>(),
                                                 new Dictionary<string, object>(),
                                                 new Mock<Controller>().Object);

        public static ActionExecutedContext ActionExecutedContext() =>
        new ActionExecutedContext(ActionContext(), new List<IFilterMetadata>(),
                                                   new Mock<Controller>().Object
                                                    );

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

        public static HttpResponseMessage MockValidRoadResponse() =>
             new HttpResponseMessage
             {
                 StatusCode = HttpStatusCode.OK,
                 Content = new StringContent(@"[{ ""id"": ""a2"", ""displayName"": ""A2"",
                                                ""statusSeverity"": ""Good"",""statusSeverityDescription"": ""No Exceptional Delays""}]"),
             };

        public static HttpResponseMessage MockInvalidRoadResponse() =>
             new HttpResponseMessage
             {
                 StatusCode = HttpStatusCode.NotFound,
                 Content = new StringContent(@"{""exceptionType"": ""EntityNotFoundException"",
                                               ""message"": ""The following road id is not recognised: A234"",
                                               ""httpStatus"": ""NotFound"",""httpStatusCode"": 404}"),
             };



    }
}
