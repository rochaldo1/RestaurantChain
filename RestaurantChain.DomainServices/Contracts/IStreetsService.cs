using RestaurantChain.Domain.Models;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с улицами
/// </summary>
public interface IStreetsService
{
    /// <summary>
    /// Получить одну запись
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Streets Get(int id);
    
    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="street"></param>
    /// <returns></returns>
    int Create(Streets street);
    
    /// <summary>
    /// Обновить
    /// </summary>
    /// <param name="street"></param>
    void Update(Streets street);
    
    /// <summary>
    /// Удалить
    /// </summary>
    /// <param name="id"></param>
    void Delete(int id);
    
    /// <summary>
    /// Получить список
    /// </summary>
    /// <returns></returns>
    IReadOnlyCollection<Streets> List();
}