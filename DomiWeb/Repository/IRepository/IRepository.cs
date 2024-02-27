using System.Linq.Expressions;

namespace DomiWeb.Repository.IRepository
{
    // IRepository<T> je generičko sučelje koje definira osnovne CRUD operacije
    public interface IRepository<T> where T : class
    {
        // Metoda za dohvaćanje svih entiteta iz skupa podataka.
        IEnumerable<T> GetAll();

        // Metoda za dohvaćanje entiteta iz skupa podataka temeljem određenog filtra definiranog lambda izrazom
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        //void Update(T entity);

        // Metoda za uklanjanje određenog entiteta iz skupa podataka.
        void Remove(T entity);

        // Metoda za uklanjanje kolekcije entiteta iz skupa podataka.
        void RemoveRange(IEnumerable<T> entity);
    }
}
