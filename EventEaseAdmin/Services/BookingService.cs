using EventEaseAdmin.Data;
using EventEaseAdmin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace EventEaseAdmin.Services
{
    public class BookingConflictException : Exception
    {
        public BookingConflictException(string message) : base(message) { }
    }

    public class BookingService
    {
        private readonly ApplicationDbContext _context;
        public BookingService(ApplicationDbContext context) { _context = context; }

        public async Task CreateBookingAsync(Booking input, CancellationToken ct = default)
        {
            var strategy = _context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using var tx = await _context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable, ct);
                var overlap = await _context.Bookings.AnyAsync(b =>
                    b.VenueId == input.VenueId &&
                    b.BookingDate == input.BookingDate &&
                    b.Status != "Cancelled",
                    ct);
                if (overlap)
                    throw new BookingConflictException("This venue is already booked for the selected time window.");
                _context.Bookings.Add(input);
                await _context.SaveChangesAsync(ct);
                await tx.CommitAsync(ct);
            });
        }
    }
}
