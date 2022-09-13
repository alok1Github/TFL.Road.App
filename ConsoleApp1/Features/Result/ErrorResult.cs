using System.Text;
using TFL.ClientApp.Model;

namespace TFL.ClientApp.Features.Result
{
    public class ErrorResult : IResult<ErrorModel>
    {
        public StringBuilder BuildResult(ErrorModel error)
        {
            if (error == null) return null;

            var result = new StringBuilder($"Error has occoured : Following are the details");
            result.AppendLine();
            result.AppendLine("-----------------------------------------------");
            result.Append($"ErrorId  : {error.ErrorId} ");
            result.AppendLine();
            result.Append($"ErrorMessage  : {error.ErrorMessage} ");
            result.AppendLine();
            result.Append($"ErrorStatusCode  : {error.ErrorStatusCode} ");
            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.WriteLine(result);
            Console.ResetColor();

            return result;
        }
    }
}
