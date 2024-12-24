using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Repository.Repositories;

/// <summary>
/// Рестораны
/// </summary>
public interface IRestaurantsRepository : IRepositoryBase<Restaurants>
{
    /// <summary>
    /// Получить ресторан по имени
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Restaurants Get(string name);
    
    /// <summary>
    /// Получить все рестораны
    /// </summary>
    /// <returns></returns>
    IReadOnlyCollection<RestaurantsView> List();
}