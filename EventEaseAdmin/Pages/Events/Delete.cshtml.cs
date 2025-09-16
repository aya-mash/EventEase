using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventEaseAdmin.Data;
using EventEaseAdmin.Models;
using System.Threading.Tasks;

namespace EventEaseAdmin.Pages.Events
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Event Event { get; set; }
        public DeleteModel(ApplicationDbContext context) { _context = context; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null) return NotFound();
            Event = await _context.Events.FindAsync(id);
            if (Event == null) return NotFound();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (Event == null) return NotFound();
            var ev = await _context.Events.FindAsync(Event.EventId);
            if (ev != null)
            {
                _context.Events.Remove(ev);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}