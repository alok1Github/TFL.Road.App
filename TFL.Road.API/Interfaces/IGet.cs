using TFL.API.Model;
using TFL.Common.Interfaces;

namespace TFL.API.Interfaces
{
    public interface IGet<Request, Response>
         where Request : IRequest
         where Response : IModel
    {
        Task<Response?> Handler(Request request);
    }
}
