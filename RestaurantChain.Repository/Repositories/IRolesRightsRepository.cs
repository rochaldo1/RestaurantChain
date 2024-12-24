using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Repository.Repositories;

public interface IRolesRightsRepository : IRepositoryBase<RolesRights>
{
    IReadOnlyCollection<RolesRightsView> List(int roleId);
    IReadOnlyCollection<UserRoleRight> ListUserRoleRights(int userId);
}