using Aspnetcoreapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aspnetcoreapp.Pages.Movies
{
    public class CreateModel(Aspnetcoreapp.Data.AspnetcoreappContext context) : PageModel
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
