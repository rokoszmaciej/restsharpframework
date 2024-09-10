using RestfulBookerTestFramework.Helpers;
using RestSharp;
using System.Net;

namespace RestfulBookerTestFramework.Utilities
{
    public static class ApiResponseHandler
    {
        public static T DeserializeResponseJson<T>(RestResponse response)
        {
            return JsonHelpers.DeserializeFromJson<T>(response.Content);
        }

        public static HttpStatusCode ResponseStatusCode(this RestResponse response)
        {
            return response.StatusCode;
        }

        public static Dictionary<string, string> ResponseHeader(this RestResponse response)
        {
            return response.Headers.ToDictionary(h => h.Name, h => h.Value.ToString());
        }
    }
}
