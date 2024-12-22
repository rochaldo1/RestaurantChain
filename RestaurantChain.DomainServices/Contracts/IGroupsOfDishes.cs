using RestaurantChain.Domain.Models;

namespace RestaurantChain.DomainServices.Contracts;

public interface IGroupsOfDishesService
{
    GroupsOfDishes Get(int id);
    int Create(GroupsOfDishes group);
    void Update(GroupsOfDishes group);
    void Delete(int id);
    IReadOnlyCollection<GroupsOfDishes> List();
}