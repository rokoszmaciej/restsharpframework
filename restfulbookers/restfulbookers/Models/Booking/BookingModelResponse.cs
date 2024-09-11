using Newtonsoft.Json;

namespace restfulbookers.Models.Booking
{
   public class BookingModelResponse
    {
        [JsonProperty("fbookingId")]
        public int bookingId {  get; set; }

        public BookingModel booking { get; set; }
    }
}
