using api.Models.Ollama;
using api.Services;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<Config>(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

//  policy.WithOrigins(["http://192.168.1.76:5149", "http://localhost:5149", "http://127.0.0.1:5149","http://0.0.0.0:5149"])

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddSingleton<MessageStore>();
builder.Services.AddHttpClient<OllamaService>();
builder.Services.AddDbContext<OllamaContext>(opt =>
    opt.UseInMemoryDatabase("Ollama"));
var app = builder.Build();
app.Urls.Add("http://192.168.1.76:5108");
app.Use(async (ctx, next) => {
    Console.WriteLine($"{ctx.Request.Method} {ctx.Request.Path}");
    await next();
});

app.UseCors("AllowSpecificOrigins");
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
public class Api
{
    public string Url { get; set; } = string.Empty;

}

public class Config()
{
    public required Api Api { get; init; } = new();
}