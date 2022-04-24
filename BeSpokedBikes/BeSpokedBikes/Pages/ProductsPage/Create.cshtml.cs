#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BeSpokedBikes.Data;
using BeSpokedBikes.Models;

namespace BeSpokedBikes.Pages.ProductsPage
{
    public class CreateModel : PageModel
    {
        private readonly BeSpokedBikes.Data.BeSpokedBikesContext _context;

        public CreateModel(BeSpokedBikes.Data.BeSpokedBikesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            //ViewData["Message"] = null;

            return Page();
        }

       

        /*When the Create form posts the form values, 
         * the ASP.NET Core runtime binds the posted values to the Products model.*/
        [BindProperty]
        public Products Products { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                //The Page method creates a PageResult
                //object that renders the Create.cshtml page.
                return Page();
            }
            /*
             * Checks each item in the data base of products
             * and compares the name of the product with the product
             * that is trying to be added. If they have the same name
             * then ViewData receives a new Key called Message and the Message
             * contains the name of the duplicate product entry.
             * Finally I returned the current page
             * In Create.cshtml I check the value of ViewData[Message] before displaying
             * popup
             */
            foreach (var item in _context.Products)
            {
                if (item.Name.Equals(Products.Name))
                {
                    ViewData["Message"] = "Table already contains "+item.Name;

                    return Page();
                }
            }
           
            _context.Products.Add(Products);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
