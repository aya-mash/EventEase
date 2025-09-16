using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventEaseAdmin.Data;
using EventEaseAdmin.Models;
using System.Threading.Tasks;

namespace EventEaseAdmin.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Booking Booking { get; set; }
        public CreateModel(ApplicationDbContext context) { _context = context; }
        public void OnGet() { }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            _context.Bookings.Add(Booking);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}