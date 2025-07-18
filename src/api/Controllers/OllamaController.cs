using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models.Ollama;
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
       
        var response = await _ollamaService.ChatCompletion(request.Model, request.Prompt);
        return Ok(new { response });
    }
}

public record ChatRequest(string Model, List<Message> Prompt);