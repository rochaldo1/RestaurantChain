using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Entities;

namespace RestaurantChain.Infrastructure.Converters;

internal static class GroupsOfDishesConverter
{
    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
    public static GroupsOfDishes ToDomain(this GroupsOfDishesDb group)
    {
        return new GroupsOfDishes
        {
            Id = group.Id,
            GroupName = group.GroupName
        };
    }
    
    /// <summary>
    /// Преобразовать доменную модель в сущность БД
    /// </summary>
    /// <returns>Сущность БД</returns>
    public static GroupsOfDishesDb ToStorage(this GroupsOfDishes group)
    {
        return new GroupsOfDishesDb
        {
            Id = group.Id,
            GroupName = group.GroupName
        };
    }
}