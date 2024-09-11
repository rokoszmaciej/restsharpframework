using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restfulbookers.Models.Booking
{
    public class BookingModel
    {
        [JsonProperty("firstname")]
        public string firstName { get; set; }

        [JsonProperty("lastname")]
        public string lastName { get; set; }

        [JsonProperty("totalprice")]
        public int totalPrice { get; set; }

        [JsonProperty("depositpaid")]
        public bool depositPaid { get; set; }

        [JsonProperty("bookingdates")]
        public BookingDates bookingDates { get; set; }

        [JsonProperty("additionalneeds")]
        public string additionalNeeds { get; set; }
    }
}
