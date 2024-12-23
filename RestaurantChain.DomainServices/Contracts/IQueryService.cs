using System.Data;

namespace RestaurantChain.DomainServices.Contracts;

public interface IQueryService
{
    DataTable ExecuteQuery(string query);
}