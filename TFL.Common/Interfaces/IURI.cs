namespace TFL.Common.Interfaces
{
    public interface IURI<Config, Request>
      where Config : IRequest
      where Request : IRequest
    {
        string BuildUri(Config settings, Request parms);
    }
}
