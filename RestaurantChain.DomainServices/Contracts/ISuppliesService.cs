using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с поставками
/// </summary>
public interface ISuppliesService
{
    /// <summary>
    /// Получить список
    /// </summary>
    /// <param name="supplierId"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    IReadOnlyCollection<SuppliesView> List(int? supplierId, DateTime? from, DateTime? to);
    
    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="supply"></param>
    /// <returns></returns>
    int Create(Supplies supply);
    
    /// <summary>
    /// Обновить
    /// </summary>
    /// <param name="supply"></param>
    void Update(Supplies supply);
    
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
    SuppliesView Get(int id);
}