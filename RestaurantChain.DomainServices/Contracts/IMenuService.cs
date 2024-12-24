using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.DomainServices.Contracts;

public interface IMenuService
{
    public IReadOnlyCollection<UserRoleRight> List(int userId);
    public IReadOnlyCollection<Menu> List();
}