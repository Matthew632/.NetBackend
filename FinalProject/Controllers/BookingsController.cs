using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using FinalProject.Repos;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : Controller
    {
        private IBookingsRepo bookingsRepo;
        public ReservationsController(IBookingsRepo bookingsRepo)
        {
            this.bookingsRepo = bookingsRepo;
        }

        [HttpGet("{id}/tables")]
        public ActionResult<LocList> GetTablesById(int id)
        {
                return bookingsRepo.GetTables(id);
            }

        [HttpGet("{id}")]
        public ActionResult<BookingsList> GetById(int id)
        {
            return bookingsRepo.GetBookings(id);
        }

        [HttpPost("")]
        public ActionResult<BookingPost> Post([FromBody]BookingPost bookingPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return bookingsRepo.PostBooking(bookingPost);

        }
    }
}