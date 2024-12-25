using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;

namespace RestaurantChain.Infrastructure.Converters;

/// <summary>
/// Конвертер моделей для Доступности продуктов в ресторане
/// </summary>
internal static class AvailibilityInRestaurantConverter
{
    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
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

    /// <summary>
    /// Преобразовать доменную модель в сущность БД
    /// </summary>
    /// <returns>Сущность БД</returns>
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

    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
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
            RestaurantName = availibility.RestaurantName,
            SumPrice = availibility.SumPrice
        };
    }
}