using restfulbookers.Models.Booking;

namespace restfulbookers.Builders
{
    public class BookingBuilder
    {
        private readonly BookingModel _bookingModel;

        public BookingBuilder(BookingModel bookingCommonModel)
        {
            _bookingModel = bookingCommonModel;
        }

        public BookingBuilder withFirstName(string firstName)
        {
            _bookingModel.firstName = firstName;
            return this;
        }

        public BookingBuilder withLastName(string lastName)
        {
            _bookingModel.lastName = lastName;
            return this;
        }

        public BookingBuilder withTotalPrice(int totalPrice)
        {
            _bookingModel.totalPrice = totalPrice;
            return this;
        }

        public BookingBuilder withDepositPaid(bool depositPaid)
        {
            _bookingModel.depositPaid = depositPaid;
            return this;
        }

        public BookingBuilder withBookingDates(DateTime checkin, DateTime checkout)
        {
            _bookingModel.bookingDates = new BookingDates
            {
                checkin = checkin,
                checkout = checkout
            };
            return this;
        }

        public BookingBuilder withAdditionalNeeds(string additionalNeeds)
        {
            _bookingModel.additionalNeeds = additionalNeeds;
            return this;
        }

        public BookingModel Build()
        {
            return _bookingModel;
        }
    }
}
