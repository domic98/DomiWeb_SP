using DomiWeb.Data;
using DomiWeb.Models;
using DomiWeb.Repository.IRepository;
using System.Linq.Expressions;

namespace DomiWeb.Repository
{
    // ArtiklRepository je implementacija repozitorija za entitet Artikl, proširuje Repository<Artikl> i implementira  IArtiklRepository.
    public class ArtiklRepository : Repository<Artikl>, IArtiklRepository
    {
        private ApplicationDbContext _db;

        // Konstruktor prima `ApplicationDbContext` objekt i prosljeđuje ga baznom konstruktoru repozitorija.
        public ArtiklRepository(ApplicationDbContext db) : base (db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Artikl obj)
        {
            _db.Artikli.Update(obj);
        }
    }
}
