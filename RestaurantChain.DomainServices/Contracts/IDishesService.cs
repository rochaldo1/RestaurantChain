using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с блюдами
/// </summary>
public interface IDishesService
{
    Dishes Get(int id);
    int Create(Dishes dish);
    void Update(Dishes dish);
    void Delete(int id);
    IReadOnlyCollection<DishesView> List();
}