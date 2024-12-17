using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Entities;

namespace RestaurantChain.Infrastructure.Converters
{
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
                OrderNum = menu.OrderNum
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
                OrderNum = menu.OrderNum
            };
        }
    }
}
