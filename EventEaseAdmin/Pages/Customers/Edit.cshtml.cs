using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventEaseAdmin.Data;
using EventEaseAdmin.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EventEaseAdmin.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Customer Customer { get; set; }
        public EditModel(ApplicationDbContext context) { _context = context; }
        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();
            Customer = await _context.Customers.FindAsync(id);
            if (Customer == null) return NotFound();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            _context.Attach(Customer).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Customers.Any(e => e.CustomerId == Customer.CustomerId)) return NotFound();
                else throw;
            }
            return RedirectToPage("Index");
        }
    }
}