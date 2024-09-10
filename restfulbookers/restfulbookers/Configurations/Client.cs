using Allure.Net.Commons;
using RestfulBookerTestFramework.Configurations;
using RestfulBookerTestFramework.Utilities;
using RestfulBookerTestFramework.Utilities.Allure;
using RestSharp;

namespace RestfulBookerTestFramework.Core
{
    public class Client
    {
        private readonly RestClient RestClient;
        private readonly string _baseUrl = ConfigurationProvider.GetTestConfiguration().ApiBaseUrl;

        public Client()
        {
            RestClient = new RestClient(_baseUrl);
        }

        public async Task<RestResponse> ExecuteRequest(RestRequest request)
        {
            Logger.LogRequestDetails(request);
            AllureUtilities.LoginRequestToAllure(request);
            var response = await RestClient.ExecuteAsync(request);
            AllureUtilities.LoginResponseToAllure(response);
            return response;
        }
    }
}
