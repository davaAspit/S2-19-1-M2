using System;
using System.Collections.Generic;

namespace CourtBooking.Data.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public DateTime BookingTime { get; set; }
        public int CourtNumber { get; set; }
        public string Booker { get; set; }

        public Court CourtNumberNavigation { get; set; }
    }
}
