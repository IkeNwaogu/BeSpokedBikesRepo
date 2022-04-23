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
using System.ComponentModel.DataAnnotations;

namespace BeSpokedBikes.Pages.SalesPage
{
    public class IndexModel : PageModel
    {
        private readonly BeSpokedBikes.Data.BeSpokedBikesContext _context;

        public IndexModel(BeSpokedBikes.Data.BeSpokedBikesContext context)
        {
            _context = context;
        }

        //[BindProperty(SupportsGet = true)] is required for binding on HTTP GET requests.
        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        public DateTime? FilterStartDate { get; set; } = null;

        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        public DateTime? FilterEndDate { get; set; } = null;

        public IList<Sales> Sales { get;set; }

        /*
        * When a request is made for the page, the OnGetAsync method returns a list of Sales to the Razor Page. 
        * On a Razor Page, OnGetAsync or OnGet is called to initialize the state of the page. 
        * In this case, OnGetAsync gets a list of Sales and displays them.
        */
        public async Task OnGetAsync()
        {
           //Placed this here so Sales table would still be filled in general even if there aren't any filters
           var sales = from _sales in _context.Sales select _sales;
            if(!string.IsNullOrEmpty(FilterStartDate.ToString()) && !string.IsNullOrEmpty(FilterEndDate.ToString()))
            {
                //LINQ query to retrieve the dates that are in the range the user specified
                sales = from sale in sales where sale.SalesDate >= FilterStartDate && sale.SalesDate <= FilterEndDate select sale;
                //Todo: Error checking for if a date that is entered is greater or less than whats in the table
            }
            
            Sales = await sales.ToListAsync();
        }
    }
}
