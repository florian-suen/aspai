using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnetcoreapp.Pages.Movies;
 

public class Movie
{
    public int Id { get; set; }
    [Column(TypeName = "text")] 
    public string? Title { get; set; }
    [Column(TypeName = "date")]
    [DataType(DataType.Date)]
    public DateOnly ReleaseDate { get; set; }
    [Column(TypeName = "text")] 
    public string? Genre { get; set; }
    public decimal Price { get; set; }
}