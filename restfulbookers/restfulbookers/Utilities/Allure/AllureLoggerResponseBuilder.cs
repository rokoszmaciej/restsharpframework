using Allure.Net.Commons;
using RestSharp;
using Parameter = Allure.Net.Commons.Parameter;

namespace RestfulBookerTestFramework.Utilities.Allure
{
    public class AllureLoggerResponseBuilder
    {
        private readonly List<Parameter> allureParams = new List<Parameter>();

        public AllureLoggerResponseBuilder WithStatusCode(RestResponse response) 
        {
            allureParams.Add(new Parameter { name = "Status code: ", value = response.StatusCode.ToString() });
            return this;
        }

        public AllureLoggerResponseBuilder WithStatusCodeDescription(RestResponse response)
        {
            allureParams.Add(new Parameter { name = "Status code description ", value = response.StatusDescription.ToString() ?? "No status description" });
            return this;
        }

        public AllureLoggerResponseBuilder WithResponseContent(RestResponse response)
        {
            allureParams.Add(new Parameter { name = "Response content ", value = response.Content.ToString() ?? string.Empty });
            return this;
        }

        public AllureLoggerResponseBuilder WithResponseStatus(RestResponse response)
        {
            allureParams.Add(new Parameter { name = "Response status ", value = response.ResponseStatus.ToString() });
            return this;
        }

        public AllureLoggerResponseBuilder WithErrorMessage(RestResponse response)
        {
            allureParams.Add(new Parameter { name = "Error message ", value = response.ErrorMessage ?? string.Empty });
            return this;
        }

        public AllureLoggerResponseBuilder WithResponseHeaders(RestResponse response)
        {
            foreach (var header in response.Headers)
            {
                allureParams.Add(new Parameter { name = $"Header: {header.Name}", value = header.Value.ToString() ?? "No headers" });
            }
            return this;
        }

        public AllureLoggerResponseBuilder WithContentHeaders(RestResponse response)
        {
            foreach (var contenHeader in response.ContentHeaders)
            {
                allureParams.Add(new Parameter { name = $"Content headers: {contenHeader.Name}", value = contenHeader.Value.ToString() ?? "No content headers" });
            }
            return this;
        }

        public List<Parameter> Build()
        {
            return allureParams;
        }
    }
}
