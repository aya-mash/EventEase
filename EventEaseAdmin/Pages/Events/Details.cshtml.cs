using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventEaseAdmin.Data;
using EventEaseAdmin.Models;
using System.Threading.Tasks;

namespace EventEaseAdmin.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public Event Event { get; set; }
        public DetailsModel(ApplicationDbContext context) { _context = context; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null) return NotFound();
            Event = await _context.Events.FindAsync(id);
            if (Event == null) return NotFound();
            return Page();
        }
    }
}