using System.Data;

namespace RestaurantChain.Repository.Repositories;

/// <summary>
/// Запросы
/// </summary>
public interface IQueryRepository
{
    /// <summary>
    /// Получить результат запроса
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    DataTable GetResult(string query);
}