using Flurl;
using TFL.API.Request;
using TFL.Common.Interfaces;

namespace TFL.API.Builder
{
    public class RoadURIBuilder : IURI<RoadConfigRequest, RoadRequest>
    {
        public string BuildUri(RoadConfigRequest settings, RoadRequest parms)
        {
            if (settings == null || parms == null) return null;

            var url = $"{settings.BaseUrl}{parms.Id}";

            return url.SetQueryParam("app_key", settings.Key)
            .SetQueryParam("app_id", settings.AppId);
        }
    }
}
