using Automation.Shared.Clients;
using Automation.Shared.Config;
using RestSharp;
using Restsharp_Nunit.Entities.Response;

namespace Restsharp_Nunit.Client
{
    internal class UserClient: BaseClient
    {

        private const string GetUsersJsonPath = "Endpoints:get_users";
        public UsersResponse GetUsers(int page)
        {
            string url = ConfigurationManager.AppSetting[GetUsersJsonPath];
            RestRequest restRequest = new(GetFullUrl(url,page.ToString()), Method.Post);
            UsersResponse resp = ExecuteRequest<UsersResponse>(restRequest);
            return resp;
        }
    }
}
