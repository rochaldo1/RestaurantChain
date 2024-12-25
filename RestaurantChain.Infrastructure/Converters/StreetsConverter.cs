using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Entities;

namespace RestaurantChain.Infrastructure.Converters;

/// <summary>
/// Конвертер моделей для улиц
/// </summary>
internal static class StreetsConverter
{
    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
    public static Streets ToDomain(this StreetsDb street)
    {
        return new Streets
        {
            Id = street.Id,
            StreetName = street.StreetName
        };
    }

    /// <summary>
    /// Преобразовать доменную модель в сущность БД
    /// </summary>
    /// <returns>Сущность БД</returns>
    public static StreetsDb ToStorage(this Streets street)
    {
        return new StreetsDb
        {
            Id = street.Id,
            StreetName = street.StreetName
        };
    }
}