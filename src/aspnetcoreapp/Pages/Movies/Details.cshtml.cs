 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
 
using Aspnetcoreapp.Models;

namespace Aspnetcoreapp.Pages.Movies
{
    public class DetailsModel(Aspnetcoreapp.Data.AspnetcoreappContext context) : PageModel
    {
        public Movie Movie { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await context.Movie.FirstOrDefaultAsync(m => m.Id == id);

            if (movie is not null)
            {
                Movie = movie;

                return Page();
            }

            return NotFound();
        }
    }
}
