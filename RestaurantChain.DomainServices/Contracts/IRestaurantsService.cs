using RestaurantChain.Domain.Models.View;
using RestaurantChain.Domain.Models;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с ресторанами
/// </summary>
public interface IRestaurantsService
{
    /// <summary>
    /// Получить одну запись
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Restaurants Get(int id);
    
    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="restaurant"></param>
    /// <returns></returns>
    int Create(Restaurants restaurant);
    
    /// <summary>
    /// Обновить
    /// </summary>
    /// <param name="restaurant"></param>
    void Update(Restaurants restaurant);
    
    /// <summary>
    /// Удалить
    /// </summary>
    /// <param name="id"></param>
    void Delete(int id);
    
    /// <summary>
    /// Получить список
    /// </summary>
    /// <returns></returns>
    IReadOnlyCollection<RestaurantsView> List();
}