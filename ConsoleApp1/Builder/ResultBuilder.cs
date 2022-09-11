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
            if (summary == null)
                return new StringBuilder($"Road Details are missing");

            var result = new StringBuilder($"The status of the  {summary.RoadDetails[0].DisplayName} is as follows ");
            result.AppendLine();
            result.AppendLine("------------------------------");
            result.Append($"Road Status is : {summary.RoadDetails[0].StatusSeverity} ");

            Console.ForegroundColor = summary.RoadDetails[0].StatusSeverity == "Good" ? ConsoleColor.Green : ConsoleColor.Red;

            result.AppendLine();
            result.Append($"Road Status Description is  : {summary.RoadDetails[0].StatusSeverityDescription} ");
            result.AppendLine("------------------------------");

            Console.WriteLine(result);

            return result;
        }
    }
}
