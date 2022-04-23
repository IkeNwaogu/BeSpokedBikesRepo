#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BeSpokedBikes.Data;
using BeSpokedBikes.Models;

namespace BeSpokedBikes.Pages.SalesPersonPage
{
    public class DeleteModel : PageModel
    {
        private readonly BeSpokedBikes.Data.BeSpokedBikesContext _context;

        public DeleteModel(BeSpokedBikes.Data.BeSpokedBikesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SalesPerson SalesPerson { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalesPerson = await _context.SalesPerson.FirstOrDefaultAsync(m => m.ID == id);

            if (SalesPerson == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalesPerson = await _context.SalesPerson.FindAsync(id);

            if (SalesPerson != null)
            {
                _context.SalesPerson.Remove(SalesPerson);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
