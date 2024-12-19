using RestaurantChain.Domain.Models;

namespace RestaurantChain.Repository.Repositories
{
    public interface IRestaurantsRepository : IRepositoryBase<Restaurants>
    {
        Restaurants Get(string name);
        IReadOnlyCollection<Restaurants> List();
    }
}
