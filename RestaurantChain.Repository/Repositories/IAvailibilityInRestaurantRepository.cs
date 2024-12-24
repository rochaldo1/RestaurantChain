using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Repository.Repositories;

/// <summary>
/// Доступность в рестороанах
/// </summary>
public interface IAvailibilityInRestaurantRepository : IRepositoryBase<AvailibilityInRestaurant>
{
    /// <summary>
    /// Список продуктов в ресторане
    /// </summary>
    /// <param name="restaurantId"></param>
    /// <returns></returns>
    IReadOnlyCollection<AvailibilityInRestaurantView> List(int? restaurantId);
    
    /// <summary>
    /// Получить один продкт из доступности
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    AvailibilityInRestaurantView GetView(int id);
    
    /// <summary>
    /// Получить продукт из доступности по ресторану продукту и цене
    /// </summary>
    /// <param name="productId">Продукт</param>
    /// <param name="restaurantId">Ресторан</param>
    /// <param name="price">Цена</param>
    /// <returns></returns>
    AvailibilityInRestaurant Get(int productId, int restaurantId, decimal price);
}