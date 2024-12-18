using RestaurantChain.Domain.Models;

namespace RestaurantChain.Repository.Repositories
{
    public interface IGroupsOfDishesRepository : IRepositoryBase<GroupsOfDishes>
    {
        GroupsOfDishes Get(string groupName);
    }
}
