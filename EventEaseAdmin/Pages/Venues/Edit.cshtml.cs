using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventEaseAdmin.Data;
using EventEaseAdmin.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EventEaseAdmin.Pages.Venues
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Venue Venue { get; set; }
        public EditModel(ApplicationDbContext context) { _context = context; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null) return NotFound();
            Venue = await _context.Venues.FindAsync(id);
            if (Venue == null) return NotFound();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            _context.Attach(Venue).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Venues.Any(e => e.VenueId == Venue.VenueId)) return NotFound();
                else throw;
            }
            return RedirectToPage("Index");
        }
    }
}