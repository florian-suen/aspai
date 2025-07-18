 
using Aspnetcoreapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aspnetcoreapp.Pages;

public class IndexModel(ILogger<IndexModel> logger) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    
    [BindProperty]
    public required Chat Chat { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Console.WriteLine(Chat.Prompt);
        
        
        

        return RedirectToPage("./Index");
    }
}
