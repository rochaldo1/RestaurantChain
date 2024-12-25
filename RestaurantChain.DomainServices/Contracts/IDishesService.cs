using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с блюдами
/// </summary>
public interface IDishesService
{
    /// <summary>
    /// Получить одну запись
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Dishes Get(int id);
    
    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="dish"></param>
    /// <returns></returns>
    int Create(Dishes dish);
    
    /// <summary>
    /// Обновить
    /// </summary>
    /// <param name="dish"></param>
    void Update(Dishes dish);
    
    /// <summary>
    /// Удалить
    /// </summary>
    /// <param name="id"></param>
    void Delete(int id);
    
    /// <summary>
    /// Получить список
    /// </summary>
    /// <returns></returns>
    IReadOnlyCollection<DishesView> List();
}