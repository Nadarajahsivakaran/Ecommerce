using E_commerce.Models;
using E_Commerce.DataServices.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.DataServices.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<Response> SendAsync(Request request)
        {
            try
            {
                var httpClient = httpClientFactory.CreateClient();
                HttpRequestMessage message = new()
                {
                    RequestUri = new Uri("https://localhost:" + request.Url)
                };

                switch (request.Type)
                {
                    case RequestType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case RequestType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case RequestType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                HttpResponseMessage apiResponse = await httpClient.SendAsync(message);

                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not Found" };
                    case HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Access Denied" };
                    case HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "Unauthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "InternalServerError" };
                    default:
                        var stream = await apiResponse.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<Response>(stream);

                }
            }
            catch (Exception ex)
            {
                return new Response() { IsSuccess = false, Message = ex.Message };
            }
        }
    }
}
