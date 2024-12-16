using RestaurantChain.Domain.Models;
using RestaurantChain.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Conventors
{
    internal static class SuppliesConvertor
    {
        public static SuppliesDomain ToDomain(this Supplies supply)
        {
            return new SuppliesDomain
            {
                Id = supply.Id,
                SupplierId = supply.SupplierId,
                ProductId = supply.ProductId,
                UnitId = supply.UnitId,
                Quantity = supply.Quantity,
                Price = supply.Price,
                SupplyDate = supply.SupplyDate
            };
        }

        public static Supplies ToStorage(this SuppliesDomain supply)
        {
            return new Supplies
            {
                Id = supply.Id,
                SupplierId = supply.SupplierId,
                ProductId = supply.ProductId,
                UnitId = supply.UnitId,
                Quantity = supply.Quantity,
                Price = supply.Price,
                SupplyDate = supply.SupplyDate
            };
        }
    }
}
