using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventEaseAdmin.Data;
using EventEaseAdmin.Models;
using System.Threading.Tasks;

namespace EventEaseAdmin.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Customer Customer { get; set; }
        public DeleteModel(ApplicationDbContext context) { _context = context; }
        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();
            Customer = await _context.Customers.FindAsync(id);
            if (Customer == null) return NotFound();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (Customer == null) return NotFound();
            var customer = await _context.Customers.FindAsync(Customer.CustomerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}