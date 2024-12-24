using RestaurantChain.Domain.Models;

namespace RestaurantChain.Repository.Repositories;

/// <summary>
/// Банки
/// </summary>
public interface IBanksRepository : IRepositoryBase<Banks>
{
    /// <summary>
    /// Получить банк по имени
    /// </summary>
    /// <param name="bankName"></param>
    /// <returns></returns>
    Banks Get(string bankName);
    
    /// <summary>
    /// Список
    /// </summary>
    /// <returns></returns>
    IReadOnlyCollection<Banks> List();
}