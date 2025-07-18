using api.Models.Ollama;
using api.Services;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        policy =>
        {
            policy.WithOrigins(
                
                    "http://localhost:5149")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials(); // Only if you need credentials/cookies
        });
});



builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));

builder.Services.AddHttpClient<OllamaService>();
builder.Services.AddDbContext<OllamaContext>(opt =>
    opt.UseInMemoryDatabase("Ollama"));
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowSpecificOrigins");

app.Run();
