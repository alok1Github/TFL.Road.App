using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using TFL.ClientApp.Features.Result;
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
        private readonly IResult<ClientModel> result;

        public GetRoadStatus(IAPIGetService<ClientModel> service,
                             IAppSettings<ClientConfigRequest> config,
                             IURI<ClientConfigRequest, ClientRequest> uri,
                             IResult<ClientModel> result)
        {
            Guard.ArgumentNotNull(service, nameof(service));
            Guard.ArgumentNotNull(config, nameof(config));
            Guard.ArgumentNotNull(uri, nameof(uri));
            Guard.ArgumentNotNull(uri, nameof(result));

            this.service = service;
            this.config = config;
            this.uri = uri;
            this.result = result;
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
