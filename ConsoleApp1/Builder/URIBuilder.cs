using Flurl;
using TFL.ClientApp.Request;
using TFL.Common.Interfaces;

namespace TFL.ClientApp.Builder
{
    public class URIBuilder : IURI<ClientConfigRequest, ClientRequest>
    {
        public string BuildUri(ClientConfigRequest settings, ClientRequest parms)
        {
            if (settings == null || parms == null) return null;

            return settings.BaseUrl.SetQueryParam("id", parms.RoadName);
        }
    }
}
