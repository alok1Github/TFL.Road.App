using System.Text;
using TFL.Common.Model;

namespace TFL.ClientApp
{
    public interface IResult
    {
        StringBuilder BuildResult(RoadModel flightDetails);
    }
}
