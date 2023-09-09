using JadCentral.Automation.Shared.Config;
using RestSharp;
using System.Text.Json;
using System.Net;
using JadCentral.Automation.Shared.Entities.Response;

namespace JadCentral.Automation.Shared.Clients.JadCentral
{
    public class BaseClient
    {
        protected readonly RestClient Client;
        private const string PingEndpointJsonPath = "Endpoints:jadCentral:ping";

        public BaseClient()
        {
            Client = new RestClient();
        }

        public T ExecuteRequest<T>(RestRequest request) where T : BaseResponse, new()
        {
            
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
