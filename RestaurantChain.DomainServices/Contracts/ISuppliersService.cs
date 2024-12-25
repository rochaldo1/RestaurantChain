using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с поставщиками
/// </summary>
public interface ISuppliersService
{
    /// <summary>
    /// Получить одну запись
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Suppliers Get(int id);
    
    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="supplier"></param>
    /// <returns></returns>
    int Create(Suppliers supplier);
    
    /// <summary>
    /// Обновить
    /// </summary>
    /// <param name="supplier"></param>
    void Update(Suppliers supplier);
    
    /// <summary>
    /// Удалить
    /// </summary>
    /// <param name="id"></param>
    void Delete(int id);
    
    /// <summary>
    /// Получить список
    /// </summary>
    /// <returns></returns>
    IReadOnlyCollection<SuppliersView> List();
}