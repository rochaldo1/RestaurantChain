using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;

namespace RestaurantChain.Infrastructure.Converters;

internal static class NomenclatureConverter
{
    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
    public static Nomenclature ToDomain(this NomenclatureDb nomenclature)
    {
        return new Nomenclature
        {
            Id = nomenclature.Id,
            RestaurantId = nomenclature.RestaurantId,
            DishId = nomenclature.DishId
        };
    }

    /// <summary>
    /// Преобразовать доменную модель в сущность БД
    /// </summary>
    /// <returns>Сущность БД</returns>
    public static NomenclatureDb ToStorage(this Nomenclature nomenclature)
    {
        return new NomenclatureDb
        {
            Id = nomenclature.Id,
            RestaurantId = nomenclature.RestaurantId,
            DishId = nomenclature.DishId
        };
    }

    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
    public static NomenclatureView ToDomain(this NomenclatureDbView nomenclature)
    {
        return new NomenclatureView
        {
            Id = nomenclature.Id,
            RestaurantId = nomenclature.RestaurantId,
            DishId = nomenclature.DishId,
            DishName = nomenclature.DishName,
            RestaurantName = nomenclature.RestaurantName,
            Price = nomenclature.Price,
            GroupId = nomenclature.GroupId,
            GroupName = nomenclature.GroupName
        };
    }
}