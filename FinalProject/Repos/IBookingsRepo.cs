using FinalProject.Models;

namespace FinalProject.Repos
{
    public interface IBookingsRepo
    {
        LocList GetTables(int id);
        BookingsList GetBookings(int id);
        BookingPost PostBooking(BookingPost bookingPost);
    }
}