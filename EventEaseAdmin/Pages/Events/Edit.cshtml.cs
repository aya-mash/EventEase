using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventEaseAdmin.Data;
using EventEaseAdmin.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EventEaseAdmin.Pages.Events
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Event Event { get; set; }
        public EditModel(ApplicationDbContext context) { _context = context; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null) return NotFound();
            Event = await _context.Events.FindAsync(id);
            if (Event == null) return NotFound();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            _context.Attach(Event).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Events.Any(e => e.EventId == Event.EventId)) return NotFound();
                else throw;
            }
            return RedirectToPage("Index");
        }
    }
}