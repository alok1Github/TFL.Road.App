using System.Text;
using TFL.ClientApp.Model;

namespace TFL.ClientApp.Features.Result
{
    public class ValidRoadResult : IResult<ClientResult>
    {
        public StringBuilder BuildResult(ClientResult roadDetails)
        {
            if (roadDetails == null) return null;

            var result = new StringBuilder();

            result.AppendLine($"The status of the  {roadDetails.DisplayName} is as follows ");
            result.AppendLine();
            result.AppendLine("-----------------------------------------");
            result.Append($"Road Status is : {roadDetails.StatusSeverity} ");

            Console.ForegroundColor = ConsoleColor.Green;

            result.AppendLine();
            result.Append($"Road Status Description is  : {roadDetails.StatusSeverityDescription} ");
            result.AppendLine();
            result.AppendLine("-----------------------------------------");

            Console.WriteLine(result);
            Console.ResetColor();

            return result;
        }
    }
}
