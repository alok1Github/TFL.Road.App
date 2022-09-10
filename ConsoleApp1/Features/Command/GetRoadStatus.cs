using TFL.ClientApp.Builder;
using TFL.ClientApp.Infrastructure;
using TFL.Common.Interfaces;
using TFL.Common.Model;
using TFL.Common.Request;

namespace TFL.ClientApp.Features.Command
{
    public class GetRoadStatus : ICommand
    {
        private readonly IAPIGetService<RoadModel> service;
        private readonly IResult result;
        public GetRoadStatus()
        {
            service = new APIBuilder();
            result = new ResultBuilder();

        }
        public async Task OnAction(string roadName)
        {
            var serviceRequest = new ServiceRequest
            {
                Uri = $"https://localhost:7111/api/Road?id={roadName}"
            };

            var summary = await service.GetData(serviceRequest);

            result.BuildResult(summary);
        }
    }
}
