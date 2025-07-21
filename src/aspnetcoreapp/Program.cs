using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Aspnetcoreapp.Data;
using Aspnetcoreapp.Models;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();
builder.Services.Configure<Config>(builder.Configuration);
builder.Services.AddDbContext<AspnetcoreappContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("aspnetcoreappContext") ?? throw new InvalidOperationException("Connection string 'aspnetcoreappContext' not found.")));
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorPages()
.WithStaticAssets();

app.Run();


public class Api
{
    public string Url { get; set; } = string.Empty;
}

public class Config()
{
    public required Api Api = new();
}