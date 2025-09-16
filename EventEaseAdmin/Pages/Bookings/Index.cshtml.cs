using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventEaseAdmin.Data;
using EventEaseAdmin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventEaseAdmin.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IList<Booking> BookingList { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            BookingList = await _context.Bookings.ToListAsync();
        }
    }
}
