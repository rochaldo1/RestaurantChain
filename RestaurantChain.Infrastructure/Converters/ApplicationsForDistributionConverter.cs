using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;

namespace RestaurantChain.Infrastructure.Converters;

internal static class ApplicationsForDistributionConverter
{
    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
    public static ApplicationsForDistribution ToDomain(this ApplicationsForDistributionDb application)
    {
        return new ApplicationsForDistribution
        {
            Id = application.Id,
            RestaurantId = application.RestaurantId,
            ProductId = application.ProductId,
            UnitId = application.UnitId,
            Quantity = application.Quantity,
            Price = application.Price,
            ApplicationDate = application.ApplicationDate
        };
    }

    /// <summary>
    /// Преобразовать доменную модель в сущность БД
    /// </summary>
    /// <returns>Сущность БД</returns>
    public static ApplicationsForDistributionDb ToStorage(this ApplicationsForDistribution application)
    {
        return new ApplicationsForDistributionDb
        {
            Id = application.Id,
            RestaurantId = application.RestaurantId,
            ProductId = application.ProductId,
            UnitId = application.UnitId,
            Quantity = application.Quantity,
            Price = application.Price,
            ApplicationDate = application.ApplicationDate
        };
    }

    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
    public static ApplicationsForDistributionView ToDomain(this ApplicationsForDistributionDbView application)
    {
        return new ApplicationsForDistributionView
        {
            Id = application.Id,
            RestaurantId = application.RestaurantId,
            ProductId = application.ProductId,
            UnitId = application.UnitId,
            Quantity = application.Quantity,
            Price = application.Price,
            ApplicationDate = application.ApplicationDate,
            SumPrice = application.SumPrice,
            UnitName = application.UnitName,
            ProductName = application.ProductName,
            RestaurantName = application.RestaurantName
        };
    }
}