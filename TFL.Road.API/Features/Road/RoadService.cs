using TFL.API.Model;
using TFL.Common.Interfaces;
using TFL.Common.Request;

namespace TFL.API.Features.Road
{
    public class RoadService : IAPIGetService<RoadModel>
    {
        private readonly IResult result;
        public RoadService(IResult result)
        {
            this.result = result;
        }

        public async Task<RoadModel?> GetData(ServiceRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request?.Uri)) return null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(request.Uri);
                client.DefaultRequestHeaders.Accept.Clear();

                var response = await client.GetAsync(request.Uri);

                return await this.result.BuildResponse(response);
            }
        }
    }
}

