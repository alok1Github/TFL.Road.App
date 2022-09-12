using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using TFL.API.ExceptionHandlers;

namespace TFL.API.filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = ExceptionResponseBuilder.createRespone(context.Exception, context.HttpContext, "Unknown Error");

            context.Result = new JsonResult(response);
        }
    }
}
