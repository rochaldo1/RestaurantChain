using System.Data;

namespace RestaurantChain.DomainServices.Contracts;

public interface IQueryService
{
    DataView ExecuteQuery(string query);
}