using RestaurantChain.Domain.Models;

namespace RestaurantChain.Repository.Repositories;

public interface IStreetsRepository : IRepositoryBase<Streets>
{
    Streets Get(string streetName);
    IReadOnlyCollection<Streets> List();
}