using System.Net.Http.Json;
using TFL.ClientApp.Model;
using TFL.Common.Interfaces;
using TFL.Common.Request;

namespace TFL.ClientApp.Builder
{
    public class APIBuilder : IAPIGetService<ClientModel>
    {
        public async Task<ClientModel?> GetData(ServiceRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request?.Uri)) return null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(request.Uri);
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response;

                try
                {
                    response = await client.GetAsync(request.Uri);

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadFromJsonAsync<ClientModel>();
                    }
                    else
                    {
                        var result = await response.Content.ReadFromJsonAsync<ErrorModel>();

                        return new ClientModel { ErrorDetails = result };
                    }
                }

                catch (Exception ex)
                {
                    return new ClientModel
                    {
                        ErrorDetails = new ErrorModel
                        {
                            ErrorId = Guid.NewGuid().ToString(),
                            ErrorMessage = ex.Message.ToString(),
                            ErrorStatusCode = 404
                        }
                    };

                }
            }
        }
    }
}
