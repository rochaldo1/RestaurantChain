using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Repository.Repositories;

/// <summary>
/// Блюда
/// </summary>
public interface IDishesRepository : IRepositoryBase<Dishes>
{
    /// <summary>
    /// Получить блюдо по имени
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Dishes Get(string name);
    
    /// <summary>
    /// Список блюд
    /// </summary>
    /// <returns></returns>
    IReadOnlyCollection<DishesView> List();
}