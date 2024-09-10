using RestfulBookerTestFramework.Builders;
using RestfulBookerTestFramework.Configurations;
using RestfulBookerTestFramework.Controllers;
using RestfulBookerTestFramework.Core;
using RestfulBookerTestFramework.Models.Auth.Response;
using RestfulBookerTestFramework.Utilities;
using System.Net;

namespace RestfulBookerTestFramework.Tests
{
    [TestFixture]
    public class AuthTests
    {
        private AuthController _authController;

        [SetUp]
        public void Setup()
        {
            var client = new Client(); // Tworzenie rzeczywistego klienta
            _authController = new AuthController(client);
        }

        [Test]
        public async Task CreateValidToken()
        {

            var validUserCredentials = ConfigurationProvider.GetTestConfiguration();
            var authorizationModel = new AuthorizationBuilder()
                .WithUserName(validUserCredentials.Username)
                .WithPassword(validUserCredentials.Password)
                .Build();


            var response = await _authController.CreateToken(authorizationModel);

            Assert.That(ApiResponseHandler.DeserializeResponseJson<TokenModel>(response).Token, Is.Not.Empty);
            Assert.That(response.ResponseStatusCode(), Is.EqualTo(HttpStatusCode.OK));
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}