using Microsoft.EntityFrameworkCore;

namespace api.Models.Ollama;

public class OllamaContext(DbContextOptions<OllamaContext> options) : DbContext(options)
{
    public DbSet<ChatDTO> Chat { get; set; } = null!;
}