using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;

namespace RestaurantChain.Infrastructure.Converters;

/// <summary>
/// Конвертер моделей для продаж
/// </summary>
internal static class SalesConverter
{
    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
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

    /// <summary>
    /// Преобразовать доменную модель в сущность БД
    /// </summary>
    /// <returns>Сущность БД</returns>
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

    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
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