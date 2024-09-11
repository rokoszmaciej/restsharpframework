using Allure.NUnit.Attributes;
using Allure.NUnit;
using restfulbookers.Builders;
using restfulbookers.Controllers;
using restfulbookers.Models.Booking;
using RestfulBookerTestFramework.Core;
using RestfulBookerTestFramework.Utilities;
using System.Net;
using Allure.Net.Commons;

namespace restfulbookers.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Booking Tests")]
    public class BookingTests
    {
        private BookingModel bookingCommonModel;
        private BookingController bookingController;

        [SetUp]
        public void SetUp()
        {
            var client = new Client();
            bookingCommonModel = new BookingModel();
            bookingController = new BookingController(client);
        }

        [Test]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureDescription("Checking if booking is proper generated")]
        [AllureStep("Create valid booking")]
        public async Task CreateBooking()
        {
            //var booking = new BookingBuilder(bookingCommonModel)
            //    .withFirstName("Jan")
            //    .withLastName("Testowy")
            //    .withTotalPrice(123)
            //    .withDepositPaid(false)
            //    .withBookingDates(DateTime.Parse("2024-03-12"), DateTime.Parse("2024-03-15"))
            //    .withAdditionalNeeds("breakfast")
            //    .Build();

            var booking = new BookingModel
            {
                firstName = "John",
                lastName = "Smith",
                totalPrice = 1234,
                depositPaid = false,
                bookingDates = new BookingDates
                {
                    checkin = DateTime.Parse("2023-04-06"),
                    checkout = DateTime.Parse("2023-04-10")
                },
                additionalNeeds = "Breakfast"
            };

            var response = await bookingController.CreateBooking(booking);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.ResponseStatusCode(), Is.EqualTo(HttpStatusCode.OK));
        }

        [TearDown]
        public void TearDown() 
        { 
        }
    }
}
