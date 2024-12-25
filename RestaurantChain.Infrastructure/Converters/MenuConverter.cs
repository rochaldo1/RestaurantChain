using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;

namespace RestaurantChain.Infrastructure.Converters;

/// <summary>
/// Конвертер моделей для меню
/// </summary>
internal static class MenuConverter
{
    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
    public static Menu ToDomain(this MenuDb menu)
    {
        return new Menu
        {
            Id = menu.Id,
            ParentId = menu.ParentId,
            DLLName = menu.DLLName,
            ItemName = menu.ItemName,
            MethodName = menu.MethodName,
            OrderNum = menu.OrderNum,
            IsMain = menu.IsMain,
        };
    }

    /// <summary>
    /// Преобразовать доменную модель в сущность БД
    /// </summary>
    /// <returns>Сущность БД</returns>
    public static MenuDb ToStorage(this Menu menu)
    {
        return new MenuDb
        {
            Id = menu.Id,
            ParentId = menu.ParentId,
            DLLName = menu.DLLName,
            ItemName = menu.ItemName,
            MethodName = menu.MethodName,
            OrderNum = menu.OrderNum,
            IsMain = menu.IsMain,
        };
    }
}