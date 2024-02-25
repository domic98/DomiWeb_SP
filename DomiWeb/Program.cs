using DomiWeb.Data;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Microsoft.AspNetCore.Identity;
using System.Configuration;
using DomiWeb.Models;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace DomiWeb
{
    public class Program
    {
        public static void Main(string[] args)

        {
            

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

           

            builder.Services.AddIdentity<IdentityUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            builder.Services.AddRazorPages();
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
