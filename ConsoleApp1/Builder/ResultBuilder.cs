using System.Text;
using TFL.ClientApp.Model;

namespace TFL.ClientApp.Builder
{
    public interface IResult
    {
        StringBuilder BuildResult(ClientModel roadDetails);
    }

    public class ResultBuilder : IResult
    {
        public StringBuilder BuildResult(ClientModel summary)
        {
            if (summary == null)
            {
                var result = new StringBuilder($"Road information are missing");
                Console.WriteLine(result);

                return result;
            }

            if (summary.ValidRoadDetails != null)
            {
                var result = new StringBuilder();
                foreach (var details in summary.ValidRoadDetails)
                {
                    PrintValidRoadResult(result, details);
                }

                return result;
            }
            else if (summary.InvalidRoadDetails != null)
            {
                return PrintInvalidRoadResult(summary);
            }

            else
            {
                var result = new StringBuilder($"Error has occoured : Following are the details");
                result.AppendLine();
                result.AppendLine("-----------------------------------------------");
                result.Append($"ErrorId  : {summary.ErrorDetails.ErrorId} ");
                result.AppendLine();
                result.Append($"ErrorMessage  : {summary.ErrorDetails.ErrorMessage} ");
                result.AppendLine();
                result.Append($"ErrorStatusCode  : {summary.ErrorDetails.ErrorStatusCode} ");
                Console.ForegroundColor = ConsoleColor.DarkRed;

                Console.WriteLine(result);
                Console.ResetColor();

                return result;
            }
        }

        private static StringBuilder PrintInvalidRoadResult(ClientModel summary)
        {
            var roadName = summary.InvalidRoadDetails.Message.Split(':');
            var result = new StringBuilder($"The status of the  {roadName[1]} is as follows ");

            result.AppendLine();
            result.AppendLine("-----------------------------------------");
            result.Append($"Road{roadName[1]} is not a valid road ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            result.AppendLine();
            result.Append($"ExceptionType type is  : {summary.InvalidRoadDetails.ExceptionType} ");
            result.AppendLine();
            result.Append($"HttpStatusCode is  : {summary.InvalidRoadDetails.HttpStatusCode} ");
            result.AppendLine();
            result.Append($"HttpStatus is  : {summary.InvalidRoadDetails.HttpStatus} ");
            result.AppendLine();
            result.AppendLine("----------------------------------------");

            Console.WriteLine(result);
            Console.ResetColor();

            return result;
        }

        private static void PrintValidRoadResult(StringBuilder result, ClientResult details)
        {
            result.AppendLine($"The status of the  {details.DisplayName} is as follows ");
            result.AppendLine();
            result.AppendLine("-----------------------------------------");
            result.Append($"Road Status is : {details.StatusSeverity} ");

            Console.ForegroundColor = ConsoleColor.Green;

            result.AppendLine();
            result.Append($"Road Status Description is  : {details.StatusSeverityDescription} ");
            result.AppendLine();
            result.AppendLine("-----------------------------------------");

            Console.WriteLine(result);
            Console.ResetColor();
        }
    }
}
