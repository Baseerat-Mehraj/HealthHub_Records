using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using HealthHub_Records.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<HealthhubDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSession(options =>
{
    options.IOTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddNotyf(config => { config.DurationInSeconds = 5; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });

builder.Services.AddHttpContextAccessor();





var app = builder.Build();





    



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();


app.UseAuthorization();
app.UseSession();

app.UseNotyf();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
