using Automation.Shared.Entities.Response;

namespace Restsharp_Nunit.Entities.Response
{
    public class UpdateUserResponse: BaseResponse
    {
        public string name { get; set; }
        public string job { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
