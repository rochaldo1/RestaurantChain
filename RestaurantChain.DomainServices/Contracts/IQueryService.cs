using System.Data;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с запросами
/// </summary>
public interface IQueryService
{
    DataTable ExecuteQuery(string query);
}