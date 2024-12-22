using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Repository.Repositories;

public interface IMenuRepository : IRepositoryBase<Menu>
{
    IReadOnlyCollection<MenuView> List();
}