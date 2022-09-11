using TFL.ClientApp.Builder;
using TFL.ClientApp.Infrastructure;
using TFL.ClientApp.Model;
using TFL.ClientApp.Request;
using TFL.Common.Interfaces;
using TFL.Common.Request;

namespace TFL.ClientApp.Features.Command
{
    public class GetRoadStatus : ICommand
    {
        private readonly IAPIGetService<ClientModel> service;
        private readonly IAppSettings<ClientConfigRequest> config;
        private readonly IURI<ClientConfigRequest, ClientRequest> uri;
        private readonly IResult result;

        public GetRoadStatus()
        {
            // Ideally this should had come from IOC
            // Gurd checking for dependenies 

            service = new APIBuilder();
            result = new ResultBuilder();
            config = new AppSettingBuilder();
            uri = new URIBuilder();
        }

        public async Task OnAction(string name)
        {
            var setting = await config.GetAppSettings();

            var serviceRequest = new ServiceRequest
            {
                Uri = uri.BuildUri(setting, new ClientRequest { RoadName = name })
            };

            var summary = await service.GetData(serviceRequest);

            result.BuildResult(summary);
        }
    }
}
