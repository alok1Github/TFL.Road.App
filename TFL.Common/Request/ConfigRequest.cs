using TFL.Common.Interfaces;

namespace TFL.Common.Request
{
    public class ConfigRequest : IRequest
    {
        public string BaseUrl { get; set; }
        public string Key { get; set; }
    }
}
