using System.Data;

namespace RestaurantChain.Repository.Repositories;

public interface IQueryRepository
{
    DataTable GetResult(string query);
}