using RestaurantChain.Domain.Models.View;
using RestaurantChain.Domain.Models;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с доступностью продуктов в ресторане
/// </summary>
public interface IAvailibilityInRestaurantService
{
    IReadOnlyCollection<AvailibilityInRestaurantView> List(int? restaurantId);
    int Create(AvailibilityInRestaurant availibilityInRestaurant);
    void Update(AvailibilityInRestaurant availibilityInRestaurant);
    void Delete(int id);
    AvailibilityInRestaurantView Get(int id);
    void UpdateCount(AvailibilityInRestaurant availibilityInRestaurant);
}