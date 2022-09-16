using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using TFL.API.Model;
using TFL.Common.Interfaces;
using TFL.Common.Request;

namespace TFL.API.Features.Road
{
    public class RoadService : IAPIGetService<RoadModel>
    {
        private readonly IResult result;

        private readonly HttpClient httpClient;
        public RoadService(HttpClient httpClient, IResult result)
        {
            Guard.ArgumentNotNull(httpClient, nameof(httpClient));
            Guard.ArgumentNotNull(result, nameof(result));

            this.result = result;
            this.httpClient = httpClient;
        }

        public async Task<RoadModel?> GetData(ServiceRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request?.Uri)) return null;

            using (this.httpClient)
            {
                this.httpClient.BaseAddress = new Uri(request.Uri);
                this.httpClient.DefaultRequestHeaders.Accept.Clear();

                var response = await this.httpClient.GetAsync(request.Uri);

                return await this.result.BuildResponse(response);
            }
        }
    }
}

