using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using POE_PART1.Data;
using Microsoft.AspNetCore.Identity;
using POE_PART1.Purchase_calculations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<POE_PART1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("POE_PART1Context") ?? throw new InvalidOperationException("Connection string 'POE_PART1Context' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>().AddDefaultTokenProviders()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<POE_PART1Context>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<Calculate_purchase>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
