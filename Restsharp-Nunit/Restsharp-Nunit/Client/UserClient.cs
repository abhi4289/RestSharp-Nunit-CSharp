using Automation.Shared.Clients;
using Automation.Shared.Config;
using Automation.Shared.Entities.Response;
using RestSharp;
using Restsharp_Nunit.Entities.Request;
using Restsharp_Nunit.Entities.Response;

namespace Restsharp_Nunit.Client
{
    internal class UserClient: BaseClient
    {

        private const string GetUsersJsonPath = "Endpoints:get_users";
        private const string CreateUserJsonPath = "Endpoints:create_user";
        private const string UpdateUserJsonPath = "Endpoints:update_user";

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

        public UpdateUserResponse UpdateUser(int id, string name, string job)
        {
            CreateUserRequest request = new(name, job);
            string url = ConfigurationManager.AppSetting[UpdateUserJsonPath];
            RestRequest restRequest = new(GetFullUrl(url, id.ToString()), Method.Put);
            restRequest.AddBody(Serialize(request));
            UpdateUserResponse resp = ExecuteRequest<UpdateUserResponse>(restRequest);
            return resp;
        }

        public BaseResponse DeleteUser(int id)
        {
            string url = ConfigurationManager.AppSetting[UpdateUserJsonPath];
            RestRequest restRequest = new(GetFullUrl(url, id.ToString()), Method.Delete);
            BaseResponse resp = ExecuteRequest<BaseResponse>(restRequest);
            return resp;
        }
    }
}
