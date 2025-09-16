using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventEaseAdmin.Data;
using EventEaseAdmin.Models;
using System.Threading.Tasks;

namespace EventEaseAdmin.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public Customer Customer { get; set; }
        public DetailsModel(ApplicationDbContext context) { _context = context; }
        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null) return NotFound();
            Customer = await _context.Customers.FindAsync(id);
            if (Customer == null) return NotFound();
            return Page();
        }
    }
}