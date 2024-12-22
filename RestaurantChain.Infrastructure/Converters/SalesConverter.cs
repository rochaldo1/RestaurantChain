using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;

namespace RestaurantChain.Infrastructure.Converters;

internal static class SalesConverter
{
    public static Sales ToDomain(this SalesDb sale)
    {
        return new Sales
        {
            Id = sale.Id,
            DishId = sale.DishId,
            RestaurantId = sale.RestaurantId,
            Quantity = sale.Quantity,
            Price = sale.Price,
            SaleDate = sale.SaleDate
        };
    }

    public static SalesDb ToStorage(this Sales sale)
    {
        return new SalesDb
        {
            Id = sale.Id,
            DishId = sale.DishId,
            RestaurantId = sale.RestaurantId,
            Quantity = sale.Quantity,
            Price = sale.Price,
            SaleDate = sale.SaleDate
        };
    }

    public static SalesView ToDomain(this SalesDbView sale)
    {
        return new SalesView
        {
            Id = sale.Id,
            DishId = sale.DishId,
            RestaurantId = sale.RestaurantId,
            Quantity = sale.Quantity,
            Price = sale.Price,
            SaleDate = sale.SaleDate,
            DishName = sale.DishName,
            GroupId = sale.GroupId,
            GroupName = sale.GroupName,
            RestaurantName = sale.RestaurantName,
            SumPrice = sale.SumPrice
        };
    }
}