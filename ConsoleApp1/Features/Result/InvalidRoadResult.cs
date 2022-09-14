using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using System.Text;
using TFL.ClientApp.Model;

namespace TFL.ClientApp.Features.Result
{
    public class InvalidRoadResult : IResult<ClientModel>
    {
        private readonly IResult<ErrorModel> errorResult;
        public InvalidRoadResult(IResult<ErrorModel> errorResult)
        {
            Guard.ArgumentNotNull(errorResult, nameof(errorResult));

            this.errorResult = errorResult;
        }

        public StringBuilder BuildResult(ClientModel roadDetails)
        {
            if (roadDetails == null) return null;

            if (roadDetails.InvalidRoadDetails == null && roadDetails.ValidRoadDetails == null)
            {
                return this.errorResult.BuildResult(roadDetails.ErrorDetails);
            }

            var roadName = roadDetails.InvalidRoadDetails.Message.Split(':');
            var result = new StringBuilder($"The status of the  {roadName[1]} is as follows ");

            result.AppendLine();
            result.AppendLine("-----------------------------------------");
            result.Append($"Road{roadName[1]} is not a valid road ");

            Console.ForegroundColor = ConsoleColor.Magenta;

            result.AppendLine();
            result.Append($"ExceptionType type is  : {roadDetails.InvalidRoadDetails.ExceptionType} ");
            result.AppendLine();
            result.Append($"HttpStatusCode is  : {roadDetails.InvalidRoadDetails.HttpStatusCode} ");
            result.AppendLine();
            result.Append($"HttpStatus is  : {roadDetails.InvalidRoadDetails.HttpStatus} ");
            result.AppendLine();
            result.AppendLine("----------------------------------------");

            Console.WriteLine(result);
            Console.ResetColor();

            return result;
        }
    }
}
