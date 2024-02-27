using DomiWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DomiWeb.Data
{
    // Klasa DbContext za Entity Framework koja je odgovorna za komunikaciju sa bazom podataka
    public class ApplicationDbContext : IdentityDbContext<IdentityUser> 
      { 
    
        // Konstruktor koji prima opcije DbContexta i prosljeđuje ih baznom konstruktoru
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        // DbSet predstavlja tablicu "Artikli" u bazi podataka.
        public DbSet<Artikl> Artikli { get; set; }
        
      
        // public DbSet<ApplicationUser> ApplicationUsers { get; set; } -- extend polja za Identity
       
        // public DbSet<Ocijena> Ocijene { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Pozivanje bazne metode za konfiguraciju Identity modela (inaće ne radi)

            base.OnModelCreating(modelBuilder);

            // Konfiguracija podataka koji će biti inicijalno dodani u tablicu Artikli. (seed podataka početnih)

            modelBuilder.Entity<Artikl>().HasData(
                new Artikl { Id = 1, Naziv = "Banane", Kategorija = "Voće", Cijena = 12, ImageUrl = "" },
                new Artikl { Id = 2, Naziv = "Jabuke", Kategorija = "Voće", Cijena = 14, ImageUrl = "" },
                new Artikl { Id = 3, Naziv = "Kruške", Kategorija = "Voće", Cijena = 11, ImageUrl = "" },
                new Artikl { Id = 4, Naziv = "Krastavac", Kategorija = "Povrće", Cijena = 10,ImageUrl = "" },
                new Artikl { Id = 5, Naziv = "Paprika", Kategorija = "Povrće", Cijena = 9, ImageUrl = ""}
                );

            
            modelBuilder.Entity<Artikl>()
                .Property(a => a.Cijena)
                .HasColumnType("decimal(18,2)");

        }
    }
}

