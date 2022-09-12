using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using TFL.API.Interfaces;
using TFL.API.Model;
using TFL.API.Request;
using TFL.Common.Interfaces;
using TFL.Common.Request;

namespace TFL.API.Features.Road
{
    public class GetRoadDetails : IGet<RoadRequest, RoadModel>
    {
        private readonly IAPIGetService<RoadModel> service;
        private readonly IAppSettings<RoadConfigRequest> config;
        private readonly IURI<RoadConfigRequest, RoadRequest> uri;
        public GetRoadDetails(IAPIGetService<RoadModel> service,
                              IAppSettings<RoadConfigRequest> config,
                              IURI<RoadConfigRequest, RoadRequest> uri)
        {
            Guard.ArgumentNotNull(service, nameof(service));
            Guard.ArgumentNotNull(config, nameof(config));
            Guard.ArgumentNotNull(uri, nameof(uri));

            this.service = service;
            this.config = config;
            this.uri = uri;
        }

        public async Task<RoadModel?> Handler(RoadRequest request)
        {
            var setting = await config.GetAppSettings();
            var uri = this.uri.BuildUri(setting, request);

            var serviceRequest = new ServiceRequest
            {
                Uri = uri
            };

            var result = await service.GetData(serviceRequest);

            return result;
        }
    }
}
