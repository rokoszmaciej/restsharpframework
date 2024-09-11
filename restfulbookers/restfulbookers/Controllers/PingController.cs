using RestfulBookerTestFramework.Builders;
using RestfulBookerTestFramework.Controllers;
using RestfulBookerTestFramework.Core;
using RestfulBookerTestFramework.Utilities.Allure;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restfulbookers.Controllers
{
    public class PingController : BaseController
    {
        private const string _path = "/ping";

        public PingController(Client client): base(client)
        {

        }

        public async Task<RestResponse> HealthCheck()
        {
            AllureUtilities.StartStepExecution(nameof(HealthCheck));
            var request = new RestRequestBuilder()
                .WithResource(_path)
                .WithMethod(Method.Get)
                .Build();

            var response = await _client.ExecuteRequest(request);
            return response;
        }
    }
}
