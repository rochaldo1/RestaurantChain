using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Repository.Repositories;

public interface IRestaurantsRepository : IRepositoryBase<Restaurants>
{
    Restaurants Get(string name);
    IReadOnlyCollection<RestaurantsView> List();
}