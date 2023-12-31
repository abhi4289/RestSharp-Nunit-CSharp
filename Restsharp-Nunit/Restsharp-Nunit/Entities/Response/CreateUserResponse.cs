﻿using Automation.Shared.Entities.Response;

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
