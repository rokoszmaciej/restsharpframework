using RestfulBookerTestFramework.Builders;
using RestfulBookerTestFramework.Core;
using RestfulBookerTestFramework.Models.Auth.Request;
using RestfulBookerTestFramework.Utilities.Allure;
using RestSharp;

namespace RestfulBookerTestFramework.Controllers
{
    public class AuthController : BaseController
    {
        private const string _path = "/auth";

        public AuthController(Client client) : base(client) 
        {
        }

        public async Task<RestResponse> CreateToken(AuthorizationModel requestBody)
        {
            AllureUtilities.StartStepExecution(nameof(CreateToken));
            var request = new RestRequestBuilder()
                .WithResource(_path)
                .WithMethod(Method.Post)
                .WithBody(requestBody)
                .Build();

            var response = await _client.ExecuteRequest(request);
            return response;
        }
    }
}
