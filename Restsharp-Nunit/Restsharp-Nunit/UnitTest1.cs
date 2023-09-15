
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
        public void Getusers()
        {
            UserClient userClient = new();
            UsersResponse response = userClient.GetUsers(1);

            Assert.That(response.data[0].email, Is.EqualTo("george.bluth@reqres.in"));

        }

        [Test]
        public void CreateUser()
        {
            UserClient userClient = new();
            CreateUserResponse response = userClient.CreateUser("Abhishek", "SDET");
            Assert.Multiple(() =>
            {
                Assert.That(response.name, Is.EqualTo("Abhishek"));
                Assert.That(response.job, Is.EqualTo("SDET"));
                Assert.That(response.id, Is.Not.Null);
            });
        }
    }
}