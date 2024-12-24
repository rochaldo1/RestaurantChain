using RestaurantChain.Domain.Models.View;
using RestaurantChain.Domain.Models;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с ресторанами
/// </summary>
public interface IRestaurantsService
{
    Restaurants Get(int id);
    int Create(Restaurants restaurant);
    void Update(Restaurants restaurant);
    void Delete(int id);
    IReadOnlyCollection<RestaurantsView> List();
}