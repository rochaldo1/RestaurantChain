using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;

namespace RestaurantChain.Infrastructure.Converters;

/// <summary>
/// Конвертер моделей для ресторанов
/// </summary>
internal static class RestaurantsConverter
{
    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
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

    /// <summary>
    /// Преобразовать доменную модель в сущность БД
    /// </summary>
    /// <returns>Сущность БД</returns>
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

    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
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