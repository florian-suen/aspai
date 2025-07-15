using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using aspnetcoreapp.Data;
 


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AspnetcoreappContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("aspnetcoreappContext") ?? throw new InvalidOperationException("Connection string 'aspnetcoreappContext' not found.")));

 
var app = builder.Build();

// Configure the HTTP request pipeline.
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

