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
        public async Task OnGetAsync()
        {
            SalesPerson = await _context.SalesPerson.ToListAsync();
        }
    }
}
