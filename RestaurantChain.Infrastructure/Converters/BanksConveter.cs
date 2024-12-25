using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Entities;

namespace RestaurantChain.Infrastructure.Converters;

/// <summary>
/// Конвертер моделей для банков
/// </summary>
internal static class BanksConverter
{
    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
    public static Banks ToDomain(this BanksDb bank)
    {
        return new Banks
        {
            Id = bank.Id,
            BankName = bank.BankName
        };
    }

    /// <summary>
    /// Преобразовать доменную модель в сущность БД
    /// </summary>
    /// <returns>Сущность БД</returns>
    public static BanksDb ToStorage(this Banks bank)
    {
        return new BanksDb
        {
            Id = bank.Id,
            BankName = bank.BankName
        };
    }
}