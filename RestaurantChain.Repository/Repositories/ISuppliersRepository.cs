using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Repository.Repositories
{
    public interface ISuppliersRepository : IRepositoryBase<Suppliers>
    {
        Suppliers Get(string name);
        IReadOnlyCollection<SuppliersView> List();
    }
}
