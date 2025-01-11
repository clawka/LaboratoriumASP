using Microsoft.AspNetCore.Identity;
using WebApp.Models;
using WebApp.Models.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();                         // dodać
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddDefaultIdentity<IdentityUser>()       // dodać
    .AddRoles<IdentityRole>()                             //
    .AddEntityFrameworkStores<AppDbContext>();     // 
builder.Services.AddTransient<IContactService, EFContactService>();
builder.Services.AddMemoryCache();                        // dodać
builder.Services.AddSession();                            // dodać    
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

app.UseAuthentication();                                 // dodać
app.UseAuthorization();                                  // dodać
app.UseSession();                                        // dodać 
app.MapRazorPages();                                     // dodać
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();