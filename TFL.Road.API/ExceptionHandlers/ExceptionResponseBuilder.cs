namespace TFL.API.ExceptionHandlers
{
    public class ExceptionResponseBuilder
    {
        public static ErrorResponseModel createRespone(Exception exception, HttpContext context, string? customMessage = null)
        {
            var errorMessage = exception == null ? customMessage
                                                 : exception.InnerException?.Message ?? exception.Message;

            var model = new ErrorResponseModel
            {
                ErrorId = Guid.NewGuid().ToString(),
                ErrorMessage = errorMessage,
                ErrorStatusCode = context.Response.StatusCode

            };

            return model;
        }
    }
}
