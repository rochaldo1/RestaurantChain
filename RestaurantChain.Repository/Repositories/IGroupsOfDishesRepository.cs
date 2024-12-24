using RestaurantChain.Domain.Models;

namespace RestaurantChain.Repository.Repositories;

/// <summary>
/// Группы блюд
/// </summary>
public interface IGroupsOfDishesRepository : IRepositoryBase<GroupsOfDishes>
{
    /// <summary>
    /// Получить по имени
    /// </summary>
    /// <returns></returns>
    GroupsOfDishes Get(string groupName);
    
    /// <summary>
    /// Список групп блюд
    /// </summary>
    /// <returns></returns>
    IReadOnlyCollection<GroupsOfDishes> List();
}