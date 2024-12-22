using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;

namespace RestaurantChain.Infrastructure.Converters;

internal static class NomenclatureConverter
{
    public static Nomenclature ToDomain(this NomenclatureDb nomenclature)
    {
        return new Nomenclature
        {
            Id = nomenclature.Id,
            RestaurantId = nomenclature.RestaurantId,
            DishId = nomenclature.DishId
        };
    }

    public static NomenclatureDb ToStorage(this Nomenclature nomenclature)
    {
        return new NomenclatureDb
        {
            Id = nomenclature.Id,
            RestaurantId = nomenclature.RestaurantId,
            DishId = nomenclature.DishId
        };
    }

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