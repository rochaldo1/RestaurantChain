using System.Data;

namespace RestaurantChain.Repository.Repositories;

public interface IQueryRepository
{
    DataView GetResult(string query);
}