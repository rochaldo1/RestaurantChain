using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;

namespace RestaurantChain.Infrastructure.Converters;

/// <summary>
/// Конвертер моделей для поставок
/// </summary>
internal static class SuppliesConverter
{
    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
    public static Supplies ToDomain(this SuppliesDb supply)
    {
        return new Supplies
        {
            Id = supply.Id,
            SupplierId = supply.SupplierId,
            ProductId = supply.ProductId,
            UnitId = supply.UnitId,
            Quantity = supply.Quantity,
            Price = supply.Price,
            SupplyDate = supply.SupplyDate
        };
    }

    /// <summary>
    /// Преобразовать доменную модель в сущность БД
    /// </summary>
    /// <returns>Сущность БД</returns>
    public static SuppliesDb ToStorage(this Supplies supply)
    {
        return new SuppliesDb
        {
            Id = supply.Id,
            SupplierId = supply.SupplierId,
            ProductId = supply.ProductId,
            UnitId = supply.UnitId,
            Quantity = supply.Quantity,
            Price = supply.Price,
            SupplyDate = supply.SupplyDate
        };
    }

    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
    public static SuppliesView ToDomain(this SuppliesDbView supply)
    {
        return new SuppliesView
        {
            Id = supply.Id,
            SupplierId = supply.SupplierId,
            ProductId = supply.ProductId,
            UnitId = supply.UnitId,
            Quantity = supply.Quantity,
            Price = supply.Price,
            SupplyDate = supply.SupplyDate,
            ProductName = supply.ProductName,
            SupplierName = supply.SupplierName,
            UnitName = supply.UnitName,
            SumPrice = supply.SumPrice,
        };
    }
}