using RestaurantChain.Domain.Models;

namespace RestaurantChain.DomainServices.Contracts;

public interface IMenuService
{
    public IReadOnlyCollection<Menu> List(int userId);
}