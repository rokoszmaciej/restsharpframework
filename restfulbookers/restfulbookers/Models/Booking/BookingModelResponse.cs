using Newtonsoft.Json;

namespace restfulbookers.Models.Booking
{
   public class BookingModelResponse
    {
        [JsonProperty("bookingId")]
        public int bookingId {  get; set; }

        public BookingModel booking { get; set; }
    }
}
