using System.Text;

namespace TFL.ClientApp.Interfaces
{
    public interface IResult<T> where T : class
    {
        StringBuilder BuildResult(T roadDetails);
    }

}
