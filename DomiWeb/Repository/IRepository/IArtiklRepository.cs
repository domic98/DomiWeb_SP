using DomiWeb.Models;

namespace DomiWeb.Repository.IRepository
{
    public interface IArtiklRepository : IRepository<Artikl>
    {
        void Update(Artikl obj);
        void Save();
    }
}
