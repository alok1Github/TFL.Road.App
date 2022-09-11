using System.Text;
using TFL.ClientApp.Model;

namespace TFL.ClientApp.Builder
{
    public interface IResult
    {
        StringBuilder BuildResult(ClientModel flightDetails);
    }

    public class ResultBuilder : IResult
    {
        public StringBuilder BuildResult(ClientModel summary)
        {
            // TO do : Corrct this
            if (summary == null)
            {
                var result = new StringBuilder($"Road information are missing");
                Console.WriteLine(result);

                return result;
            }

            if (summary.RoadDetails != null)
            {
                var result = new StringBuilder($"The status of the  {summary.RoadDetails[0].DisplayName} is as follows ");
                result.AppendLine();
                result.AppendLine("-----------------------------------------");
                result.Append($"Road Status is : {summary.RoadDetails[0].StatusSeverity} ");

                Console.ForegroundColor = ConsoleColor.Green;

                result.AppendLine();
                result.Append($"Road Status Description is  : {summary.RoadDetails[0].StatusSeverityDescription} ");
                result.AppendLine();
                result.AppendLine("-----------------------------------------");

                Console.WriteLine(result);
                Console.ResetColor();

                return result;
            }
            else
            {
                var roadName = summary.Errordetails.Message.Split(':');
                var result = new StringBuilder($"The status of the  {roadName[1]} is as follows ");

                result.AppendLine();
                result.AppendLine("-----------------------------------------");
                result.Append($"Road : {roadName[1]} is not a valid road ");

                result.AppendLine();
                result.Append($"Following are details :");
                result.AppendLine();

                Console.ForegroundColor = ConsoleColor.Red;

                result.AppendLine();
                result.Append($"exceptionType type is  : {summary.Errordetails.ExceptionType} ");
                result.AppendLine();
                result.Append($"httpStatusCode is  : {summary.Errordetails.HttpStatusCode} ");
                result.AppendLine();
                result.Append($"httpStatus is  : {summary.Errordetails.HttpStatus} ");
                result.AppendLine();
                result.AppendLine("----------------------------------------");

                Console.WriteLine(result);
                Console.ResetColor();

                return result;

            }
        }
    }
}
