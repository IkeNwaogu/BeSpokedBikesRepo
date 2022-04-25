using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BeSpokedBikes.Models;
using BeSpokedBikes.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<BeSpokedBikesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BeSpokedBikesContext") ?? throw new InvalidOperationException("Connection string 'BeSpokedBikesContext' not found.")));


var app = builder.Build();

/*Gets a database context instance from the dependency injection (DI) container.
 * Call the seedData.Initialize method, passing to it the database context instance.
 * Dispose the context when the seed method completes. The using statement ensures the context is disposed.
 */
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
    Report.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();



app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
