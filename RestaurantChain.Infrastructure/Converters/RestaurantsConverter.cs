using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;

namespace RestaurantChain.Infrastructure.Converters;

internal static class RestaurantsConverter
{
    public static Restaurants ToDomain(this RestaurantsDb restaurant)
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

    public static RestaurantsView ToDomain(this RestaurantsDbView restaurant)
    {
        return new RestaurantsView
        {
            Id = restaurant.Id,
            StreetId = restaurant.StreetId,
            RestaurantName = restaurant.RestaurantName,
            DirectorName = restaurant.DirectorName,
            DirectorLastName = restaurant.DirectorLastName,
            DirectorSurname = restaurant.DirectorSurname,
            PhoneNumber = restaurant.PhoneNumber,
            StreetName = restaurant.StreetName
        };
    }
}