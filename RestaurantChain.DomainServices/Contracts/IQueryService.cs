using System.Data;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с запросами
/// </summary>
public interface IQueryService
{
    /// <summary>
    /// Выполнить запрос
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    DataTable ExecuteQuery(string query);
}