using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventEaseAdmin.Data;
using EventEaseAdmin.Models;
using System.Threading.Tasks;

namespace EventEaseAdmin.Pages.Venues
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public Venue Venue { get; set; }
        public DetailsModel(ApplicationDbContext context) { _context = context; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null) return NotFound();
            Venue = await _context.Venues.FindAsync(id);
            if (Venue == null) return NotFound();
            return Page();
        }
    }
}