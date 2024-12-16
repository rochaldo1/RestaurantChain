using RestaurantChain.Domain.Models;
using RestaurantChain.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Conventors
{
    internal static class RestaurantsConvertor
    {
        public static RestaurantsDomain ToDomain(this Restaurants restaurant)
        {
            return new RestaurantsDomain
            {
                Id = restaurant.Id,
                StreetId = restaurant.StreetId,
                RestaurantName = restaurant.RestaurantName,
                DirectorName = restaurant.DirectorName,
                DirectorLastName = restaurant.DirectorLastName,
                DirectorSurname = restaurant.DirectorSurname,
                PhoneNumber = restaurant.PhoneNumber
            };
        }

        public static Restaurants ToStorage(this RestaurantsDomain restaurant)
        {
            return new Restaurants
            {
                Id = restaurant.Id,
                StreetId = restaurant.StreetId,
                RestaurantName = restaurant.RestaurantName,
                DirectorName = restaurant.DirectorName,
                DirectorLastName = restaurant.DirectorLastName,
                DirectorSurname = restaurant.DirectorSurname,
                PhoneNumber = restaurant.PhoneNumber
            };
        }
    }
}
