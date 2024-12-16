using RestaurantChain.Domain.Models;
using RestaurantChain.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Conventors
{
    internal static class MenuConvertor
    {
        public static MenuDomain ToDomain(this Menu menu)
        {
            return new MenuDomain
            {
                Id = menu.Id,
                ParentId = menu.ParentId,
                DLLName = menu.DLLName,
                ItemName = menu.ItemName,
                MethodName = menu.MethodName,
                OrderNum = menu.OrderNum
            };
        }

        public static Menu ToStorage(this MenuDomain menu)
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
    }
}
