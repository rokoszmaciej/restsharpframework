using Allure.Net.Commons;
using RestSharp;


namespace RestfulBookerTestFramework.Utilities.Allure
{
    public static class AllureUtilities
    {
        public static void StartStepExecution(string stepName)
        {
            var stepDetails = new StepResult
            {
                name = stepName
            };

            AllureLifecycle.Instance.StartStep(stepDetails);
        }

        public static void StopStepExecution()
        {
            AllureLifecycle.Instance.StopStep();
        }

        public static void LoginRequestToAllure(RestRequest request)
        {
            var allureParams = new AllureLoggerRequestBuilder()
                .WithResourceUrl(request)
                .WithMethod(request)
                .WithQueryParam(request)
                .WithHeader(request)
                .WithBody(request)
                .Build();

            AllureLifecycle.Instance.StartStep(new StepResult
            {
                name = "Request:",
                parameters = allureParams
            });

            StopStepExecution();
        }

        public static void LoginResponseToAllure(RestResponse response)
        {
            var allureParams = new AllureLoggerResponseBuilder()
                .WithResponseStatus(response)
                .WithStatusCode(response)
                .WithStatusCodeDescription(response)
                .WithResponseContent(response)
                .WithContentHeaders(response)
                .WithResponseHeaders(response)
                .WithErrorMessage(response)
                .Build();

            AllureLifecycle.Instance.StartStep(new StepResult
            {
                name = "Request:",
                parameters = allureParams
            });

            StopStepExecution();
        }
    }
}
