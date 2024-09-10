using RestfulBookerTestFramework.Configurations;
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
            var response = await RestClient.ExecuteAsync(request);
            return response;
        }
    }
}
