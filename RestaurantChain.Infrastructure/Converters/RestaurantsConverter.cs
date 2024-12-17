using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Entities;

namespace RestaurantChain.Infrastructure.Converters
{
    internal static class RestaurantsConverter
    {
        public static Restaurants ToDomain(this Restaurants restaurant)
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

        public static RestaurantsDb ToStorage(this Restaurants restaurant)
        {
            return new RestaurantsDb
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
