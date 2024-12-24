using RestaurantChain.Domain.Models;

namespace RestaurantChain.Repository.Repositories;

/// <summary>
/// Справочник - единицы измерения
/// </summary>
public interface IUnitsRepository : IRepositoryBase<Units>
{
    /// <summary>
    /// Получить по имени
    /// </summary>
    /// <param name="unitName"></param>
    /// <returns></returns>
    Units Get(string unitName);
    
    /// <summary>
    /// Получить список
    /// </summary>
    /// <returns></returns>
    IReadOnlyCollection<Units> List();
}