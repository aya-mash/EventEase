using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventEaseAdmin.Data;
using EventEaseAdmin.Models;
using System.Threading.Tasks;

namespace EventEaseAdmin.Pages.Bookings
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public Booking Booking { get; set; }
        public DetailsModel(ApplicationDbContext context) { _context = context; }
        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();
            Booking = await _context.Bookings.FindAsync(id);
            if (Booking == null) return NotFound();
            return Page();
        }
    }
}