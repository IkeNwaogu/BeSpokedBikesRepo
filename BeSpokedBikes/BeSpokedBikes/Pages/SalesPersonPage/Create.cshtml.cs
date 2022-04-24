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

namespace BeSpokedBikes.Pages.SalesPersonPage
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
            return Page();
        }

        [BindProperty]
        public SalesPerson SalesPerson { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            /*
             * Checks each item in the data base of SalesPerson
             * and compares the name of the Sales Person with the Sales Person
             * that is trying to be added. If they have the same name
             * then ViewData receives a new Key called Message and the Message
             * contains the name of the duplicate Sales Person entry.
             * Finally I returned the current page
             * In Create.cshtml I check the value of ViewData[Message] before displaying
             * popup
             */
            foreach (var item in _context.SalesPerson)
            {
                if (item.FirstName.Equals(SalesPerson.FirstName) && item.LastName.Equals(SalesPerson.LastName))
                {
                    ViewData["Message"] = "Table already contains " + item.FirstName+" "+item.LastName;

                    return Page();
                }
            }


            _context.SalesPerson.Add(SalesPerson);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
