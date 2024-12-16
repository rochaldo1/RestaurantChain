using RestaurantChain.Domain.Models;
using RestaurantChain.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Conventors
{
    internal static class DishesConvertor
    {
        public static DishesDomain ToDomain(this Dishes dish)
        {
            return new DishesDomain
            {
                Id = dish.Id,
                GroupId = dish.GroupId,
                DishName = dish.DishName,
                Price = dish.Price
            };
        }

        public static Dishes ToStorage(this DishesDomain dish)
        {
            return new Dishes
            {
                Id = dish.Id,
                GroupId = dish.GroupId,
                DishName = dish.DishName,
                Price = dish.Price
            };
        }
    }
}
