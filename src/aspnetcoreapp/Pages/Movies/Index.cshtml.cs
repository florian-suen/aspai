using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using aspnetcoreapp.Data;

namespace aspnetcoreapp.Pages.Movies
{
    public class IndexModel(aspnetcoreapp.Data.AspnetcoreappContext context) : PageModel
    {
        public required IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await context.Movie.ToListAsync();
        }
    }
}
