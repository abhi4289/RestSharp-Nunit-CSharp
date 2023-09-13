
using Restsharp_Nunit.Client;
using Restsharp_Nunit.Entities.Response;

namespace Restsharp_Nunit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            UserClient userClient = new();
            UsersResponse response = userClient.GetUsers(1);

            Assert.AreEqual(response.data[0].email, "george.bluth@reqres.in");

        }
    }
}