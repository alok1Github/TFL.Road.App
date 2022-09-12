using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using System.Text;
using TFL.ClientApp.Model;

namespace TFL.ClientApp.Features.Result
{
    public interface IResult<T> where T : class
    {
        StringBuilder BuildResult(T roadDetails);
    }

    public class ResultHandler : IResult<ClientModel>
    {
        private readonly IResult<ClientResult> validResult;
        private readonly IResult<InvaildResult> inValidResult;
        private readonly IResult<ErrorModel> errorResult;

        public ResultHandler(IResult<ErrorModel> errorResult,
                             IResult<ClientResult> validResult,
                             IResult<InvaildResult> inValidResult)
        {
            Guard.ArgumentNotNull(errorResult, nameof(errorResult));
            Guard.ArgumentNotNull(validResult, nameof(validResult));
            Guard.ArgumentNotNull(inValidResult, nameof(inValidResult));

            this.errorResult = errorResult;
            this.validResult = validResult;
            this.inValidResult = inValidResult;
        }

        public StringBuilder BuildResult(ClientModel summary)
        {
            if (summary == null)
            {
                return DefaultResult();
            }

            if (summary.ValidRoadDetails != null)
            {
                return GetValidResult(summary);
            }
            else if (summary.InvalidRoadDetails != null)
            {
                return this.inValidResult.BuildResult(summary.InvalidRoadDetails);
            }

            else if (summary.ErrorDetails != null)
            {
                return this.errorResult.BuildResult(summary.ErrorDetails);
            }

            return DefaultResult();
        }

        private StringBuilder GetValidResult(ClientModel summary)
        {
            var results = new List<StringBuilder>();

            foreach (var details in summary.ValidRoadDetails)
            {
                var result = this.validResult.BuildResult(details);

                results.Add(result);
            }

            var validResullt = new StringBuilder(results.ToString());

            return validResullt;
        }

        private static StringBuilder DefaultResult()
        {
            var result = new StringBuilder($"Road information are missing");
            Console.WriteLine(result);

            return result;
        }
    }
}
