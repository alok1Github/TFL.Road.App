using Microsoft.Extensions.Configuration;
using TFL.ClientApp.Request;
using TFL.Common.Interfaces;

namespace TFL.ClientApp.Builder
{
    public class AppSettingBuilder : IAppSettings<ClientConfigRequest>
    {
        public Task<ClientConfigRequest> GetAppSettings() =>
       Task.Run(() => new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json")
                                .Build()
                                .GetSection(nameof(ClientConfigRequest)).Get<ClientConfigRequest>()
                    );
    }
}
