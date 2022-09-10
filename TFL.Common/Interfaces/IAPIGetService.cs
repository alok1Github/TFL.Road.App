using TFL.Common.Request;

namespace TFL.Common.Interfaces
{
    public interface IAPIGetService<T> where T : class
    {
        Task<T?> GetData(ServiceRequest request);
    }

}
