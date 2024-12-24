using RestaurantChain.Domain.Models;

namespace RestaurantChain.Repository.Repositories;

/// <summary>
/// Справочник улицы
/// </summary>
public interface IStreetsRepository : IRepositoryBase<Streets>
{
    /// <summary>
    /// Улица по имени
    /// </summary>
    /// <param name="streetName"></param>
    /// <returns></returns>
    Streets Get(string streetName);
    
    /// <summary>
    /// Список всех улиц
    /// </summary>
    /// <returns></returns>
    IReadOnlyCollection<Streets> List();
}