using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Repository.Repositories;

public interface IDishesRepository : IRepositoryBase<Dishes>
{
    Dishes Get(string name);
    IReadOnlyCollection<DishesView> List();
}