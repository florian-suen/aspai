using Microsoft.AspNetCore.Mvc;
using api.Services;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController(OllamaService ollamaService) : ControllerBase
{
    private readonly OllamaService _ollamaService = ollamaService;

    [HttpPost]
    public async Task<IActionResult> ChatCompletion(
        [FromBody] ChatRequest request)
    {
        Console.WriteLine(request.Model);
        var response = await _ollamaService.ChatCompletion(request.Model, request.Prompt);
        return Ok(new { response });
    }
}

public record ChatRequest(string Model, List<Message> Prompt);