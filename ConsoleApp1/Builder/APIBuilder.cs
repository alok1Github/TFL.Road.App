using System.Net.Http.Json;
using TFL.Common.Interfaces;
using TFL.Common.Model;
using TFL.Common.Request;

namespace TFL.ClientApp.Builder
{
    public class APIBuilder : IAPIGetService<RoadModel>
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
                    return await response.Content.ReadFromJsonAsync<RoadModel>();
                }
            }

            return null;
        }
    }
}
