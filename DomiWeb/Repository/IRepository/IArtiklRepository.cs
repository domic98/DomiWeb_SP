using DomiWeb.Models;

namespace DomiWeb.Repository.IRepository
{
    // `IArtiklRepository` je sučelje koje proširuje `IRepository<Artikl>` i definira dodatne metode specifične za entitet `Artikl`.
    public interface IArtiklRepository : IRepository<Artikl>
    {
        void Update(Artikl obj);
        void Save();
    }
}
