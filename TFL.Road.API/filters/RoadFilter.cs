using Microsoft.AspNetCore.Mvc.Filters;

namespace TFL.API.filters
{
    public class RoadFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // var result = ((StatusCodeResult)context.Result).StatusCode;

            //if (result == 404)
            //{
            //    // var value = ((InvaildValidRoadResult?)((ObjectResult?)context.Result).Value);

            //}

        }
    }
}
