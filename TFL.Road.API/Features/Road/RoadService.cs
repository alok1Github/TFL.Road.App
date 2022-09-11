using TFL.API.Model;
using TFL.Common.Interfaces;
using TFL.Common.Request;

namespace TFL.API.Features.Road
{
    public class RoadService : IAPIGetService<RoadModel>
    {
        public async Task<RoadModel?> GetData(ServiceRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request?.Uri)) return null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(request.Uri);
                client.DefaultRequestHeaders.Accept.Clear();

                var response = await client.GetAsync(request.Uri);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<List<ValidRoadResult>>();

                    return new RoadModel { RoadDetails = result };
                }
                else
                {
                    var result = await response.Content.ReadFromJsonAsync<InvaildValidRoadResult>();

                    return new RoadModel { Errordetails = result };
                }
            }

        }
    }
}

