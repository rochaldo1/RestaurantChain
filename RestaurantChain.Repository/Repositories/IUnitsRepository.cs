using RestaurantChain.Domain.Models;

namespace RestaurantChain.Repository.Repositories
{
    public interface IUnitsRepository : IRepositoryBase<Units>
    {
        Units Get(string unitName);
    }
}
