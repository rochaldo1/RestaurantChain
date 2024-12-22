using RestaurantChain.Domain.Models;

namespace RestaurantChain.Repository.Repositories;

public interface IMenuRepository : IRepositoryBase<Menu>
{
    IReadOnlyCollection<Menu> List();
}