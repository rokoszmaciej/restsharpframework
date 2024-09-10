using RestfulBookerTestFramework.Helpers;
using RestfulBookerTestFramework.Models;
using RestSharp;
using Parameter = Allure.Net.Commons.Parameter;

namespace RestfulBookerTestFramework.Utilities.Allure
{
    public class AllureLoggerRequestBuilder
    {
        private List<Parameter> allureParams = new List<Parameter>();

        public AllureLoggerRequestBuilder WithMethod(RestRequest request)
        {
            allureParams.Add(new Parameter
            {
                name = "HTTP Method: ",
                value = request.Method.ToString()
            });
            return this;
        }

        public AllureLoggerRequestBuilder WithResourceUrl(RestRequest request)
        {
            allureParams.Add(new Parameter
            {
                name = "Resource URL: ",
                value = request.Resource
            });
            return this;
        }

        public AllureLoggerRequestBuilder WithBody(RestRequest request)
        {
            var bodyParam = JsonHelpers.SerializeToJson(
                request.Parameters.FirstOrDefault(x => x.Type == ParameterType.RequestBody).Value);
            if (bodyParam != null)
            {
                allureParams.Add(new Parameter { name = "Body: ", value = bodyParam });
            }
            return this;
        }

        public AllureLoggerRequestBuilder WithHeader(RestRequest request)
        {
            foreach (var header in request.Parameters.Where(p => p.Type == ParameterType.HttpHeader))
            {
                allureParams.Add(new Parameter { name = $"Header: {header.Name}", value = header.Value.ToString() });
            }
            return this;
        }

        public AllureLoggerRequestBuilder WithQueryParam(RestRequest request)
        {
            foreach (var param in request.Parameters.Where(p => p.Type == ParameterType.QueryString))
            {
                allureParams.Add(new Parameter { name = $"Query Param: {param.Name}", value = param.Value.ToString() });
            }
            return this;
        }

        public List<Parameter> Build()
        {
            return allureParams;
        }
    }
}
