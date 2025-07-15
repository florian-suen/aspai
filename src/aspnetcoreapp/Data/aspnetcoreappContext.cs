using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using aspnetcoreapp.Pages.Movies;

namespace aspnetcoreapp.Data
{
    public class AspnetcoreappContext(DbContextOptions<AspnetcoreappContext> options) : DbContext(options)
    {
        public DbSet<aspnetcoreapp.Pages.Movies.Movie> Movie { get; set; } = default!;
    }
}
