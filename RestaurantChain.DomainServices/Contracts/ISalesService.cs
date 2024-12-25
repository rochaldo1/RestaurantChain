using RestaurantChain.Domain.Models.View;
using RestaurantChain.Domain.Models;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с продажами
/// </summary>
public interface ISalesService
{
    /// <summary>
    /// Получить список
    /// </summary>
    /// <param name="restaurantId"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    IReadOnlyCollection<SalesView> List(int? restaurantId, DateTime? from, DateTime? to);
    
    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="sales"></param>
    /// <returns></returns>
    int Create(Sales sales);
    
    /// <summary>
    /// Обновить
    /// </summary>
    /// <param name="sales"></param>
    void Update(Sales sales);
    
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
    Sales Get(int id);
}