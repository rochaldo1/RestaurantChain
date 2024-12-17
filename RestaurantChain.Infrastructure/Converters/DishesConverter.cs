using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Entities;

namespace RestaurantChain.Infrastructure.Converters
{
    internal static class DishesConverter
    {
        public static Dishes ToDomain(this DishesDb dish)
        {
            return new Dishes
            {
                Id = dish.Id,
                GroupId = dish.GroupId,
                DishName = dish.DishName,
                Price = dish.Price
            };
        }

        public static DishesDb ToStorage(this Dishes dish)
        {
            return new DishesDb
            {
                Id = dish.Id,
                GroupId = dish.GroupId,
                DishName = dish.DishName,
                Price = dish.Price
            };
        }
    }
}
