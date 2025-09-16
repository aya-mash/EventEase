using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventEaseAdmin.Data;
using EventEaseAdmin.Models;
using System.Threading.Tasks;

namespace EventEaseAdmin.Pages.Venues
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Venue Venue { get; set; }
        public DeleteModel(ApplicationDbContext context) { _context = context; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null) return NotFound();
            Venue = await _context.Venues.FindAsync(id);
            if (Venue == null) return NotFound();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (Venue == null) return NotFound();
            var venue = await _context.Venues.FindAsync(Venue.VenueId);
            if (venue != null)
            {
                _context.Venues.Remove(venue);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}