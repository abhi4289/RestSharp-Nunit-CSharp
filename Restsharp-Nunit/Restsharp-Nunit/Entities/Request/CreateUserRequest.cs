using Automation.Shared.Entities.Request;

namespace Restsharp_Nunit.Entities.Request
{
    public class CreateUserRequest: BaseRequest
    {
        public CreateUserRequest(string name, string job)
        {
            this.name = name;
            this.job = job;
        }

        public string name { get; set; }
        public string job { get; set; }
    }
}
