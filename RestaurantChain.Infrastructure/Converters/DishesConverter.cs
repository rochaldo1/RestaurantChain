using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;

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

        public static DishesView ToDomain(this DishesDbView dish)
        {
            return new DishesView
            {
                Id = dish.Id,
                GroupId = dish.GroupId,
                DishName = dish.DishName,
                Price = dish.Price,
                GroupName = dish.GroupName
            };
        }
    }
}
