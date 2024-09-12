using Allure.NUnit.Attributes;
using Allure.NUnit;
using restfulbookers.Builders;
using restfulbookers.Controllers;
using restfulbookers.Models.Booking;
using RestfulBookerTestFramework.Core;
using RestfulBookerTestFramework.Utilities;
using System.Net;
using Allure.Net.Commons;
using RestfulBookerTestFramework.Configurations;
using RestfulBookerTestFramework.Builders;
using RestfulBookerTestFramework.Controllers;
using RestfulBookerTestFramework.Models.Auth.Response;
using FluentAssertions;

namespace restfulbookers.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Booking Tests")]
    public class BookingTests
    {
        private BookingModel bookingCommonModel;
        private BookingController bookingController;
        private AuthController authController;

        [SetUp]
        public void SetUp()
        {
            var client = new Client();
            bookingCommonModel = new BookingModel();
            bookingController = new BookingController(client);
            authController = new AuthController(client);
        }

        [Test]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureDescription("Checking if booking is proper generated")]
        [AllureStep("Create valid booking")]
        public async Task CreateBooking()
        {
            var booking = new BookingBuilder(bookingCommonModel)
                    .withFirstName("Jan")
                    .withLastName("Testowy")
                    .withTotalPrice(123)
                    .withDepositPaid(false)
                    .withBookingDates(DateTime.Parse("2024-03-12"), DateTime.Parse("2024-03-15"))
                    .withAdditionalNeeds("breakfast")
                    .Build();

            var response = await bookingController.CreateBooking(booking);
            Assert.That(ApiResponseHandler.DeserializeResponseJson<BookingModelResponse>(response).booking.firstName, Is.EqualTo("Jan"));
            Assert.That(response.ResponseStatusCode(), Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureDescription("Checking if booking is updated")]
        [AllureStep("Update booking")]
        public async Task UpdateBooking()
        {
            var validUserCredentials = ConfigurationProvider.GetTestConfiguration();
            var authorizationModel = new AuthorizationBuilder()
            .WithUserName(validUserCredentials.Username)
                .WithPassword(validUserCredentials.Password)
                .Build();

            var authResponse = await authController.CreateToken(authorizationModel);
            var token = ApiResponseHandler.DeserializeResponseJson<TokenModel>(authResponse).Token;

            var booking = ConfigurationProvider.GetBookingData();

            var createBookingResponse = await bookingController.CreateBooking(booking);
            var createdBookingId = ApiResponseHandler.DeserializeResponseJson<BookingModelResponse>(createBookingResponse).bookingId;

            var updatedBooking = new BookingBuilder(bookingCommonModel)
                    .withFirstName("Jan1")
                    .withLastName("Testowy1")
                    .withTotalPrice(1234)
                    .withDepositPaid(true)
                    .withBookingDates(DateTime.Parse("2024-04-12"), DateTime.Parse("2024-04-15"))
                    .withAdditionalNeeds("dinner")
                    .Build();

            var updateBookingResponse = await bookingController.UpdateBooking(updatedBooking, token, createdBookingId);
            var deserializedResponse = ApiResponseHandler.DeserializeResponseJson<BookingModel>(updateBookingResponse);
            deserializedResponse.Should().BeEquivalentTo(updatedBooking);
            updateBookingResponse.ResponseStatusCode().Should().Be(HttpStatusCode.OK);
        }

        [Test]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureDescription("Checking if booking is partially updated")]
        [AllureStep("Partial update booking")]
        public async Task PartialUpdateBooking()
        {
            var validUserCredentials = ConfigurationProvider.GetTestConfiguration();
            var authorizationModel = new AuthorizationBuilder()
                .WithUserName(validUserCredentials.Username)
                .WithPassword(validUserCredentials.Password)
                .Build();

            var authResponse = await authController.CreateToken(authorizationModel);
            var token = ApiResponseHandler.DeserializeResponseJson<TokenModel>(authResponse).Token;

            var booking = ConfigurationProvider.GetBookingData();

            var createBookingResponse = await bookingController.CreateBooking(booking);
            var createdBookingId = ApiResponseHandler.DeserializeResponseJson<BookingModelResponse>(createBookingResponse).bookingId;

            var partialUpdatedBooking = new BookingBuilder(bookingCommonModel)
                    .withFirstName("Jan1")
                    .withLastName("Testowy1")
                    .withTotalPrice(booking.totalPrice)
                    .withDepositPaid(booking.depositPaid)
                    .withBookingDates(booking.bookingDates.checkin, booking.bookingDates.checkout)
                    .withAdditionalNeeds(booking.additionalNeeds)
                    .Build();

            var updateBookingResponse = await bookingController.PartialUpdateBooking(partialUpdatedBooking, token, createdBookingId);
            var deserializedResponse = ApiResponseHandler.DeserializeResponseJson<BookingModel>(updateBookingResponse);
            deserializedResponse.Should().BeEquivalentTo(partialUpdatedBooking);
            updateBookingResponse.ResponseStatusCode().Should().Be(HttpStatusCode.OK);
        }

        [Test]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureDescription("Checking if booking is removed")]
        [AllureStep("Delete booking")]
        public async Task DeleteBooking()
        {
            var validUserCredentials = ConfigurationProvider.GetTestConfiguration();
            var authorizationModel = new AuthorizationBuilder()
                .WithUserName(validUserCredentials.Username)
                .WithPassword(validUserCredentials.Password)
                .Build();

            var authResponse = await authController.CreateToken(authorizationModel);
            var token = ApiResponseHandler.DeserializeResponseJson<TokenModel>(authResponse).Token;

            var booking = ConfigurationProvider.GetBookingData();

            var createBookingResponse = await bookingController.CreateBooking(booking);
            var createdBookingId = ApiResponseHandler.DeserializeResponseJson<BookingModelResponse>(createBookingResponse).bookingId;

            var deleteBookingResponse = await bookingController.DeleteBooking(token, createdBookingId);
            deleteBookingResponse.ResponseStatusCode().Should().Be(HttpStatusCode.Created);
        }

        [TearDown]
        public void TearDown() 
        { 
        }
    }
}
