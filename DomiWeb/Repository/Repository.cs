using DomiWeb.Data;
using DomiWeb.Repository.IRepository;
using Microsoft.CodeAnalysis.Scripting.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DomiWeb.Repository
{
    // Repository<T> je generički repozitorij koji pruža osnovne CRUD operacije
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _db;
         
        //`dbSet` predstavlja skup podataka za entitete u bazi podataka

        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db) 
        {
            _db = db;
            
            // `dbSet` je postavljen na skup podataka u bazi podataka, što omogućuje pristup i manipulaciju entitetima tog tipa.

            this.dbSet = _db.Set<T>();
           // _db.Categories == dbSet
        }

        // Metoda za dodavanje novog entiteta u skup podataka (`dbSet`)
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        // Metoda za dohvaćanje entiteta iz skupa podataka temeljem određenog filtra definiranog lambda izrazom
        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        // Metoda za dohvaćanje svih entiteta iz skupa podataka
        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }
       
        // Metoda za uklanjanje određenog entiteta iz skupa podataka.
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        // Metoda za uklanjanje kolekcije entiteta iz skupa podataka.
        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
