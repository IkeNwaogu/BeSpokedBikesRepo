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
    public class IndexModel : PageModel
    {
        private readonly BeSpokedBikes.Data.BeSpokedBikesContext _context;

        public IndexModel(BeSpokedBikes.Data.BeSpokedBikesContext context)
        {
            _context = context;
        }

        public IList<SalesPerson> SalesPerson { get;set; }

        /*
        * When a request is made for the page, the OnGetAsync method returns a list of SalesPersons to the Razor Page. 
        * On a Razor Page, OnGetAsync or OnGet is called to initialize the state of the page. 
        * In this case, OnGetAsync gets a list of SalesPersons and displays them.
        */
        public async Task<IActionResult> OnGetAsync()
        {
            /*
             * If our Sales Person table already has entry with
             * the given first and last name then send user back to edit page
             * so they can change the first and last name
             */
            SalesPerson = await _context.SalesPerson.ToListAsync();
            for (int current = 0; current < SalesPerson.Count; current++)
            {
                for (int next = current + 1; next < SalesPerson.Count; next++)
                {
                    if (SalesPerson[current].FirstName.Equals(SalesPerson[next].FirstName) && SalesPerson[current].LastName.Equals(SalesPerson[next].LastName))
                    {
                        return LocalRedirect("/SalesPersonPage/Edit?id=" + SalesPerson[next].ID);
                    }
                }
            }
            return Page();
        }
    }
}
