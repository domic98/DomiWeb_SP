using DomiWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DomiWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Artikl> Artikli { get; set; }

       // public DbSet<Ocijena> Ocijene { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Artikl>().HasData(
                new Artikl { Id = 1, Naziv = "Banane", Kategorija = "Voće", Cijena = 12, ImageUrl = "" },
                new Artikl { Id = 2, Naziv = "Jabuke", Kategorija = "Voće", Cijena = 14, ImageUrl = "" },
                new Artikl { Id = 3, Naziv = "Kruške", Kategorija = "Voće", Cijena = 11, ImageUrl = "" },
                new Artikl { Id = 4, Naziv = "Krastavac", Kategorija = "Povrće", Cijena = 10,ImageUrl = "" },
                new Artikl { Id = 5, Naziv = "Paprika", Kategorija = "Povrće", Cijena = 9, ImageUrl = ""}
                );

        }
    }
}
