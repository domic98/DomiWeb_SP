using DomiWeb.Data;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Microsoft.AspNetCore.Identity;
using System.Configuration;
using DomiWeb.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using DomiWeb.Repository.IRepository;
using DomiWeb.Repository;

namespace DomiWeb
{
    public class Program
    {
        public static void Main(string[] args)

        {
            

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Konfiguracija Dependency Injection za DbContext (ApplicationDbContext) s SQL Server bazom podataka.

            builder.Services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Dodavanje servisa u Dependency Injection kontejner.
            // Scoped servis koji implementira IArtiklRepository koristi se tijekom trajanja jednog HTTP zahtjeva.

            builder.Services.AddScoped<IArtiklRepository, ArtiklRepository>();


            // Konfiguracija Identity usluge s korištenjem IdentityUser i IdentityRole klasa.

            builder.Services.AddIdentity<IdentityUser,IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


            builder.Services.AddRazorPages();

            // Konfiguracija opcija za Application Cookie u Identity sustavu.

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });


            

            builder.Services.AddScoped<IEmailSender,EmailSender>();    

            var app = builder.Build();


            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

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

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Artikl}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
