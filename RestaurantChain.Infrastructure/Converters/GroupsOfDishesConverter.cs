using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Entities;

namespace RestaurantChain.Infrastructure.Converters
{
    internal static class GroupsOfDishesConverter
    {
        public static GroupsOfDishes ToDomain(this GroupsOfDishesDb group)
        {
            return new GroupsOfDishes
            {
                Id = group.Id,
                GroupName = group.GroupName
            };
        }

        public static GroupsOfDishesDb ToStorage(this GroupsOfDishes group)
        {
            return new GroupsOfDishesDb
            {
                Id = group.Id,
                GroupName = group.GroupName
            };
        }
    }
}
