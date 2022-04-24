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

namespace BeSpokedBikes.Pages.ProductsPage
{
    public class IndexModel : PageModel
    {
        private readonly BeSpokedBikes.Data.BeSpokedBikesContext _context;

        public IndexModel(BeSpokedBikes.Data.BeSpokedBikesContext context)
        {
            _context = context;
        }

        public IList<Products> Products { get;set; }

        /*
         * When a request is made for the page, the OnGetAsync method returns a list of products to the Razor Page. 
         * On a Razor Page, OnGetAsync or OnGet is called to initialize the state of the page. 
         * In this case, OnGetAsync gets a list of products and displays them.
         */
        public async Task<IActionResult> OnGetAsync()
        {
            /*
            * If our Products Person table already has entry with
            * the given product name then send user back to edit page
            * so they can change the product name
            */

            Products = await _context.Products.ToListAsync();
            for (int current = 0; current < Products.Count; current++)
            {
                for (int next = current + 1; next < Products.Count; next++)
                {
                    if (Products[current].Name.Equals(Products[next].Name) && Products[current].Style.Equals(Products[next].Style))
                    { 
                        //ViewData["Redirect"]= "Redirected";
                        //ViewData["Message"] = "Table already contains " + Products[next].Name;
                        //String temp = ViewData["Message"].ToString();
                        //Page();
                        return LocalRedirect("/ProductsPage/Edit?id=" + Products[next].ID);
                    }
                }
            }
            return Page();
        }
    }
}
