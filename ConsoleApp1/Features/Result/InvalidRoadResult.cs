using System.Text;
using TFL.ClientApp.Model;

namespace TFL.ClientApp.Features.Result
{
    public class InvalidRoadResult : IResult<InvaildResult>
    {
        public StringBuilder BuildResult(InvaildResult roadDetails)
        {
            var roadName = roadDetails.Message.Split(':');
            var result = new StringBuilder($"The status of the  {roadName[1]} is as follows ");

            result.AppendLine();
            result.AppendLine("-----------------------------------------");
            result.Append($"Road{roadName[1]} is not a valid road ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            result.AppendLine();
            result.Append($"ExceptionType type is  : {roadDetails.ExceptionType} ");
            result.AppendLine();
            result.Append($"HttpStatusCode is  : {roadDetails.HttpStatusCode} ");
            result.AppendLine();
            result.Append($"HttpStatus is  : {roadDetails.HttpStatus} ");
            result.AppendLine();
            result.AppendLine("----------------------------------------");

            Console.WriteLine(result);
            Console.ResetColor();

            return result;
        }
    }
}
