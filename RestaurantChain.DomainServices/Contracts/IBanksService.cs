using RestaurantChain.Domain.Models;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с банками
/// </summary>
public interface IBanksService
{
    /// <summary>
    /// Получить одну запись
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Banks Get(int id);
    
    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="bank"></param>
    /// <returns></returns>
    int Create(Banks bank);
    
    /// <summary>
    /// Обновить
    /// </summary>
    /// <param name="bank"></param>
    void Update(Banks bank);
    
    /// <summary>
    /// Удалить
    /// </summary>
    /// <param name="id"></param>
    void Delete(int id);
    
    /// <summary>
    /// Получить список
    /// </summary>
    /// <returns></returns>
    IReadOnlyCollection<Banks> List();
}