using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Entities;

namespace RestaurantChain.Infrastructure.Converters;

internal static class UnitsConverter
{
    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
    public static Units ToDomain(this UnitsDb unit)
    {
        return new Units
        {
            Id = unit.Id,
            UnitName = unit.UnitName
        };
    }

    /// <summary>
    /// Преобразовать доменную модель в сущность БД
    /// </summary>
    /// <returns>Сущность БД</returns>
    public static UnitsDb ToStorage(this Units unit)
    {
        return new UnitsDb
        {
            Id = unit.Id,
            UnitName = unit.UnitName
        };
    }
}