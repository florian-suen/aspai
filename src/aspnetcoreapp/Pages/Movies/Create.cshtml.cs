using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using aspnetcoreapp.Data;

namespace aspnetcoreapp.Pages.Movies
{
    public class CreateModel(aspnetcoreapp.Data.AspnetcoreappContext context) : PageModel
    {
        public IActionResult OnGet()
        {
           return Page();
        }

        [BindProperty]
        public required Movie Movie { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            context.Movie.Add(Movie);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
