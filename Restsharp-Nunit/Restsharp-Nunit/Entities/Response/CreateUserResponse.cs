using Automation.Shared.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restsharp_Nunit.Entities.Response
{
    public class CreateUserResponse: BaseResponse
    {
        public string name { get; set; }
        public string job { get; set; }
        public string id { get; set; }
        public DateTime createdAt { get; set; }
    }
}
