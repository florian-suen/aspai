using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aspnetcoreapp.Models;
 

public class Movie
{
    public int Id { get; set; }
    
    [StringLength(60, MinimumLength = 3)]
    [Required]
    [Column(TypeName = "text")] 
    public string? Title { get; set; }
    [Column(TypeName = "date")]
    [DataType(DataType.Date)]
    [Display (Name = "Release Date")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime ReleaseDate { get; set; }
    [Column(TypeName = "text")] 
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [Required]
    public string? Genre { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    
    [Range(1, 100)]
    public decimal Price { get; set; }
    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    [StringLength(5)]
    [Required]
    public string Rating { get; set; } = string.Empty;
}