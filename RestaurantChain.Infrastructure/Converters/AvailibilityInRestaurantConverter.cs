using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;

namespace RestaurantChain.Infrastructure.Converters;

internal static class AvailibilityInRestaurantConverter
{
    public static AvailibilityInRestaurant ToDomain(this AvailibilityInRestaurantDb availibility)
    {
        return new AvailibilityInRestaurant
        {
            Id = availibility.Id,
            RestaurantId = availibility.RestaurantId,
            ProductId = availibility.ProductId,
            UnitId = availibility.UnitId,
            Quantity = availibility.Quantity,
            Price = availibility.Price
        };
    }

    public static AvailibilityInRestaurantDb ToStorage(this AvailibilityInRestaurant availibility)
    {
        return new AvailibilityInRestaurantDb
        {
            Id = availibility.Id,
            RestaurantId = availibility.RestaurantId,
            ProductId = availibility.ProductId,
            UnitId = availibility.UnitId,
            Quantity = availibility.Quantity,
            Price = availibility.Price
        };
    }

    public static AvailibilityInRestaurantView ToDomain(this AvailibilityInRestaurantDbView availibility)
    {
        return new AvailibilityInRestaurantView
        {
            Id = availibility.Id,
            RestaurantId = availibility.RestaurantId,
            ProductId = availibility.ProductId,
            UnitId = availibility.UnitId,
            Quantity = availibility.Quantity,
            Price = availibility.Price,
            UnitName = availibility.UnitName,
            ProductName = availibility.ProductName,
            RestaurantName = availibility.RestaurantName
        };
    }
}