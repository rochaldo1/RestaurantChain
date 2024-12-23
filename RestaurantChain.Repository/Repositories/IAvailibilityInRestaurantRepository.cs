using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Repository.Repositories;

public interface IAvailibilityInRestaurantRepository : IRepositoryBase<AvailibilityInRestaurant>
{
    IReadOnlyCollection<AvailibilityInRestaurantView> List(int? restaurantId);
    AvailibilityInRestaurantView GetView(int id);
    AvailibilityInRestaurant Get(int productId, int restaurantId, decimal price);
}