using TFL.API.Request;
using TFL.Common.Interfaces;

namespace TFL.API.Features.Road
{
    public class RoadAppSetting : IAppSettings<RoadConfigRequest>
    {
        public Task<RoadConfigRequest> GetAppSettings() =>
       Task.Run(() => new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json")
                                .Build()
                                .GetSection(nameof(RoadConfigRequest)).Get<RoadConfigRequest>()
                    );
    }
}
