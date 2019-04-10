using System;
using System.Collections.Generic;

namespace CourtBooking.Data.Models
{
    public partial class Court
    {
        public Court()
        {
            Bookings = new HashSet<Booking>();
        }

        public int CourtNumber { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
