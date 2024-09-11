using restfulbookers.Builders;
using restfulbookers.Models.Booking;
using RestfulBookerTestFramework.Builders;
using RestfulBookerTestFramework.Controllers;
using RestfulBookerTestFramework.Core;
using RestfulBookerTestFramework.Utilities.Allure;
using RestSharp;

namespace restfulbookers.Controllers
{
    public class BookingController : BaseController
    {
        private const string _path = "/booking";

        public BookingController(Client client): base(client) 
        { 
        }

        public async Task<RestResponse> CreateBooking(BookingModel booking)
        {
            AllureUtilities.StartStepExecution(nameof(CreateBooking));

            var request = new RestRequestBuilder()
                .WithResource(_path)
                .WithMethod(Method.Post)
                .WithHeader(KnownHeaders.Accept, ContentType.Json)
                .WithJsonBody(booking)
                .Build();
               
            var response = await _client.ExecuteRequest(request);
            return response;
        }
    }
}
