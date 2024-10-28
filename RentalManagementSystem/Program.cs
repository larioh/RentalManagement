using Microsoft.EntityFrameworkCore;
using RentalManagementSystem.Data;
using System.Configuration;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Dbcontext
builder.Services.AddDbContext<ApplicationDbcontext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Blazor server-side services
builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

// Add Radzen services
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Configure Blazor server-side middleware
app.MapRazorComponents<App>()
   .AddInteractiveServerComponents();

app.Run();
