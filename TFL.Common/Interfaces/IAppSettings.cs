namespace TFL.Common.Interfaces
{
    public interface IAppSettings<T> where T : class
    {
        Task<T> GetAppSettings();
    }
}
