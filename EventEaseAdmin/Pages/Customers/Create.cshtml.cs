using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventEaseAdmin.Data;
using EventEaseAdmin.Models;
using System.Threading.Tasks;

namespace EventEaseAdmin.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Customer Customer { get; set; }
        public CreateModel(ApplicationDbContext context) { _context = context; }
        public void OnGet() { }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}