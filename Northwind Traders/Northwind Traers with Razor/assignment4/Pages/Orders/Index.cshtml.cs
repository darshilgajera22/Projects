using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using assignment4.Data;
using assignment4.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace assignment4.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly assignment4.Data.NorthwindContext _context;

        public IndexModel(assignment4.Data.NorthwindContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;
        public List<SelectListItem> representatives { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SelectedReps { get; set; }

        public async Task OnGetAsync()
        {
            var reps = await _context.Employees.OrderBy(o => o.LastName).ToListAsync();

            representatives = reps.Select(e => new SelectListItem { Value = e.EmployeeId.ToString(), Text=$"{e.FirstName} {e.LastName}"}).ToList();

            var orders = await _context.Orders
                .Include(o => o.Employee)
                .Include(o => o.ShipViaNavigation)
                .Where(o => o.Freight >= 250)
                .ToListAsync();

            Order = SelectedReps > 0 ? orders.Where(o => o.EmployeeId == SelectedReps).ToList() : orders;
        }
    }
}
