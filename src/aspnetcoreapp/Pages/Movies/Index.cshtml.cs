using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Aspnetcoreapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aspnetcoreapp.Pages.Movies
{
    public class IndexModel(Aspnetcoreapp.Data.AspnetcoreappContext context) : PageModel
    {
        public required IList<Movie> Movie { get;set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }
        
        
        
        
        public async Task OnGetAsync()
        {
            
            var movies = from m in context.Movie
                select m;
            
            IQueryable<string> genreQuery = from m in context.Movie
                orderby m.Genre
                select m.Genre;
            
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title != null && s.Title.Contains(SearchString));
            }
            
            
            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }

          
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            
            
            
            
            
            
            Movie = await movies.ToListAsync();
        }
    }
}
