using RestaurantChain.Domain.Models;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с единицами измерения
/// </summary>
public interface IUnitsService
{
    /// <summary>
    /// Получить одну запись
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Units Get(int id);
    
    /// <summary>
    /// Создать
    /// </summary>
    /// <param name="unit"></param>
    /// <returns></returns>
    int Create(Units unit);
    
    /// <summary>
    /// Обновить
    /// </summary>
    /// <param name="unit"></param>
    void Update(Units unit);
    
    /// <summary>
    /// Удалить
    /// </summary>
    /// <param name="id"></param>
    void Delete(int id);
    
    /// <summary>
    /// Получить список
    /// </summary>
    /// <returns></returns>
    IReadOnlyCollection<Units> List();
}