using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using System.Text;
using TFL.ClientApp.Model;

namespace TFL.ClientApp.Features.Result
{
    public interface IResult<ResultModel> where ResultModel : class
    {
        StringBuilder BuildResult(ResultModel roadDetails);
    }

    public class ResultHandler : IResult<ClientModel>
    {
        private readonly IResult<ClientResult> validResult;
        private readonly IResult<ClientModel> invalidResult;

        public ResultHandler(IResult<ClientResult> validResult, IResult<ClientModel> inValidResult)
        {
            Guard.ArgumentNotNull(validResult, nameof(validResult));
            Guard.ArgumentNotNull(inValidResult, nameof(inValidResult));

            this.validResult = validResult;
            this.invalidResult = inValidResult;
        }

        public StringBuilder BuildResult(ClientModel summary)
        {
            if (summary == null) return DefaultResult();

            var result = GetRoadResult(summary);

            if (result == null)
            {
                result = this.invalidResult.BuildResult(summary);
            }

            if (result == null) return DefaultResult();

            return result;
        }

        private StringBuilder GetRoadResult(ClientModel summary)
        {
            if (summary.ValidRoadDetails == null) return null;

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
