using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventEaseAdmin.Data;
using EventEaseAdmin.Models;
using System.Threading.Tasks;

namespace EventEaseAdmin.Pages.Bookings
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Booking Booking { get; set; }
        public DeleteModel(ApplicationDbContext context) { _context = context; }
        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();
            Booking = await _context.Bookings.FindAsync(id);
            if (Booking == null) return NotFound();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (Booking == null) return NotFound();
            var booking = await _context.Bookings.FindAsync(Booking.BookingId);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}