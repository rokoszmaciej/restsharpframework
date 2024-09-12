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
        private const string _Path = "/booking";

        public BookingController(Client client): base(client) 
        { 
        }

        public async Task<RestResponse> CreateBooking(BookingModel booking)
        {
            AllureUtilities.StartStepExecution(nameof(CreateBooking));

            var request = new RestRequestBuilder()
                .WithResource(_Path)
                .WithMethod(Method.Post)
                .WithHeader(KnownHeaders.Accept, ContentType.Json)
                .WithJsonBody(booking)
                .Build();
               
            var response = await _client.ExecuteRequest(request);
            return response;
        }

        public async Task<RestResponse> UpdateBooking(BookingModel booking, string token, int bookingId)
        {
            AllureUtilities.StartStepExecution(nameof(UpdateBooking));

            var request = new RestRequestBuilder()
                .WithResource($"{_Path}/{bookingId}")
                .WithMethod(Method.Put)
                .WithHeader(KnownHeaders.Accept, ContentType.Json)
                .WithHeader(KnownHeaders.ContentType, ContentType.Json)
                .WithHeader(KnownHeaders.Cookie, $"token={token}")
                .WithJsonBody(booking)
                .Build();

            var response = await _client.ExecuteRequest(request);
            return response;
        }

        public async Task<RestResponse> PartialUpdateBooking(BookingModel booking, string token, int bookingId)
        {
            AllureUtilities.StartStepExecution(nameof(PartialUpdateBooking));

            var request = new RestRequestBuilder()
                .WithResource($"{_Path}/{bookingId}")
                .WithMethod(Method.Patch)
                .WithHeader(KnownHeaders.Accept, ContentType.Json)
                .WithHeader(KnownHeaders.ContentType, ContentType.Json)
                .WithHeader(KnownHeaders.Cookie, $"token={token}1")
                .WithJsonBody(booking)
                .Build();

            var response = await _client.ExecuteRequest(request);
            return response;
        }

        public async Task<RestResponse> DeleteBooking(string token, int bookingId)
        {
            AllureUtilities.StartStepExecution(nameof(DeleteBooking));

            var request = new RestRequestBuilder()
                .WithResource($"{_Path}/{bookingId}")
                .WithMethod(Method.Delete)
                .WithHeader(KnownHeaders.ContentType, ContentType.Json)
                .WithHeader(KnownHeaders.Cookie, $"token={token}")
                .Build();

            var response = await _client.ExecuteRequest(request);
            return response;
        }
    }
}
