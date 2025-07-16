using Microsoft.EntityFrameworkCore;

namespace Aspnetcoreapp.Data
{
    public class AspnetcoreappContext(DbContextOptions<AspnetcoreappContext> options) : DbContext(options)
    {
        public DbSet<Aspnetcoreapp.Models.Movie> Movie { get; set; } = null!;
    }
}
