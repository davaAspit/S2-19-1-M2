using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourtBooking.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourtBooking.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly valsby_dk_dbContext context;
        public BookingsController(valsby_dk_dbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetBooking()
        {
            return new ObjectResult(context.Bookings);
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking([FromRoute] int id)
        {
            var booking = context.Bookings.SingleOrDefault(b => b.BookingId == id);
            return new ObjectResult(booking);
        }
    }
}