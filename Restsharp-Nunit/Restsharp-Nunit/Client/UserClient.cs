using Automation.Shared.Clients;
using Automation.Shared.Config;
using RestSharp;
using Restsharp_Nunit.Entities.Request;
using Restsharp_Nunit.Entities.Response;

namespace Restsharp_Nunit.Client
{
    internal class UserClient: BaseClient
    {

        private const string GetUsersJsonPath = "Endpoints:get_users";
        private const string CreateUserJsonPath = "Endpoints:create_user";

        public UsersResponse GetUsers(int page)
        {
            string url = ConfigurationManager.AppSetting[GetUsersJsonPath];
            RestRequest restRequest = new(GetFullUrl(url,page.ToString()), Method.Get);
            UsersResponse resp = ExecuteRequest<UsersResponse>(restRequest);
            return resp;
        }

        public CreateUserResponse CreateUser(string name, string job)
        {
            CreateUserRequest request = new(name, job);
            string url = ConfigurationManager.AppSetting[CreateUserJsonPath];
            RestRequest restRequest = new(url, Method.Post);
            restRequest.AddBody(Serialize(request));
            CreateUserResponse resp = ExecuteRequest<CreateUserResponse>(restRequest);
            return resp;
        }
    }
}
