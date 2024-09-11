using Allure.NUnit.Attributes;
using Allure.NUnit;
using restfulbookers.Controllers;
using RestfulBookerTestFramework.Core;
using RestfulBookerTestFramework.Utilities;
using System.Net;
using Allure.Net.Commons;


namespace restfulbookers.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Health check tests")]
    public class PingTests
    {
        private PingController _pingController;

        [SetUp]
        public void SetUp()
        {
            var client = new Client();
            _pingController = new PingController(client);
        }

        [Test]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureDescription("A simple health check endpoint to confirm whether the API is up and running")]
        [AllureStep("Health check")]
        [AllureTag("Smoke")]
        public async Task HealthCheck()
        {
            var response = await _pingController.HealthCheck();

            Assert.That(response.ResponseStatusCode(), Is.EqualTo(HttpStatusCode.Created));
        }

        [TearDown]
        public void TearDown() 
        { 
        }

    }
}
