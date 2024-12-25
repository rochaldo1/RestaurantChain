using RestaurantChain.Domain.Models.View;
using RestaurantChain.Domain.Models;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с доступностью продуктов в ресторане
/// </summary>
public interface IAvailibilityInRestaurantService
{
    /// <summary>
    /// Получить список
    /// </summary>
    /// <param name="restaurantId"></param>
    /// <returns></returns>
    IReadOnlyCollection<AvailibilityInRestaurantView> List(int? restaurantId);
    
    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="availibilityInRestaurant"></param>
    /// <returns></returns>
    int Create(AvailibilityInRestaurant availibilityInRestaurant);
    
    /// <summary>
    /// Обновить
    /// </summary>
    /// <param name="availibilityInRestaurant"></param>
    void Update(AvailibilityInRestaurant availibilityInRestaurant);
    
    /// <summary>
    /// Удалить
    /// </summary>
    /// <param name="id"></param>
    void Delete(int id);
    
    /// <summary>
    /// Получить одну запись
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    AvailibilityInRestaurantView Get(int id);
    
    /// <summary>
    /// Обновить количество
    /// </summary>
    /// <param name="availibilityInRestaurant"></param>
    void UpdateCount(AvailibilityInRestaurant availibilityInRestaurant);
}