using RestaurantChain.Domain.Models;

namespace RestaurantChain.Repository.Repositories;

public interface IRolesRepository : IRepositoryBase<Roles>
{
    IReadOnlyCollection<Roles> List();
}