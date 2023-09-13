using RestSharp;
using System.Text.Json;
using Automation.Shared.Entities.Response;
using Automation.Shared.Config;

namespace Automation.Shared.Clients
{
    public class BaseClient
    {
        protected readonly RestClient Client;

        public BaseClient()
        {
            Client = new RestClient(ConfigurationManager.AppSetting["BaseUrl"]);
        }

        public T ExecuteRequest<T>(RestRequest request) where T : BaseResponse, new()
        {
            RestResponse response = Client.Execute<T>(request);
            Console.WriteLine($"Url : {request.Resource} ======> Response:  {response.Content}");

            T resp = JsonSerializer.Deserialize<T>(response.Content);

            resp.ResponseCode = (int)response.StatusCode;
            return resp;
        }

        protected string GetFullUrl(string url, params string[] args)
        {
            for (int i = 1; i <= args.Length; i++)
            {
                url = url.Replace($"${{{i}}}", args[i - 1]);
            }
            return url;
        }

        public string Serialize<T>(T request)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            return JsonSerializer.Serialize(request, request.GetType(), options);
        }
    }
}
