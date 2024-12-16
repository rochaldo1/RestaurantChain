using RestaurantChain.Domain.Models;
using RestaurantChain.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Conventors
{
    internal static class SalesConvertor
    {
        public static SalesDomain ToDomain (this Sales sale)
        {
            return new SalesDomain
            {
                Id = sale.Id,
                DishId = sale.DishId,
                RestaurantId = sale.RestaurantId,
                Quantity = sale.Quantity,
                Price = sale.Price,
                SaleDate = sale.SaleDate
            };
        }

        public static Sales ToStorage(this SalesDomain sale)
        {
            return new Sales
            {
                Id = sale.Id,
                DishId = sale.DishId,
                RestaurantId = sale.RestaurantId,
                Quantity = sale.Quantity,
                Price = sale.Price,
                SaleDate = sale.SaleDate
            };
        }
    }
}
