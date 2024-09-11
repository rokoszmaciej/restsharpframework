using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restfulbookers.Models.Booking
{
    public class BookingDates
    {
        [JsonProperty("checkin")]
        public DateTime checkin { get; set; }

        [JsonProperty("checkout")]
        public DateTime checkout { get; set; }
    }
}
