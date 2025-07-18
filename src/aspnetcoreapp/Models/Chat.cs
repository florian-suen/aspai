using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aspnetcoreapp.Models;

public class Chat
{
   [StringLength(60, MinimumLength = 3)]
   [Required]
   [Column(TypeName = "text")] 
   [Display(Name = "Message")]
  public  string? Prompt  { get; set; }
   
}


 