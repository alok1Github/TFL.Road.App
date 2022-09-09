using TFL.API.Interfaces;
using TFL.API.Model;
using TFL.API.Request;

namespace TFL.API.Features.Road
{
    public class GetRoadDetails : IGet<RoadRequest, RoadModel>
    {
        public async Task<RoadModel?> Handler(RoadRequest request)
        {
            using (var client = new HttpClient())
            {
                //  client.BaseAddress = new Uri(request.Uri);
                client.DefaultRequestHeaders.Accept.Clear();

                var response = await client.GetAsync("https://api.tfl.gov.uk/Road/A2?app_id=xyz&app_key=7b662d8e60624c2b9b2ccaedaba91cd5");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<List<RoadResult>>();

                    return new RoadModel { RoadDetails = result };
                }

            }
            return null;
        }
    }
}
