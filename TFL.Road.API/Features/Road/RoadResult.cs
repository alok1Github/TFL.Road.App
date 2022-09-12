using TFL.API.Model;

namespace TFL.API.Features.Road
{
    public interface IResult
    {
        Task<RoadModel> BuildResponse(HttpResponseMessage response);
    }

    public class RoadResult : IResult
    {
        public async Task<RoadModel> BuildResponse(HttpResponseMessage response)
        {
            if (response == null)
            {
                return null;
            }

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<ValidRoadResult>>();

                return new RoadModel { ValidRoadDetails = result };
            }
            else
            {
                var result = await response.Content.ReadFromJsonAsync<InvaildValidRoadResult>();

                return new RoadModel { InvalidRoadDetails = result };
            }
        }
    }
}
