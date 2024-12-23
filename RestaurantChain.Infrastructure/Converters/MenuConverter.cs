using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;

namespace RestaurantChain.Infrastructure.Converters;

internal static class MenuConverter
{
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

    public static MenuView ToDomain(this MenuDbView menu)
    {
        return new MenuView
        {
            Id = menu.Id,
            ParentId = menu.ParentId,
            DLLName = menu.DLLName,
            ItemName = menu.ItemName,
            MethodName = menu.MethodName,
            OrderNum = menu.OrderNum,
            Level = menu.Level,
            IsMain = menu.IsMain,
        };
    }
}