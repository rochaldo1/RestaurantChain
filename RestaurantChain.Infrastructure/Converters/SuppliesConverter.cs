using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Entities;

namespace RestaurantChain.Infrastructure.Converters
{
    internal static class SuppliesConverter
    {
        public static Supplies ToDomain(this SuppliesDb supply)
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

        public static SuppliesDb ToStorage(this Supplies supply)
        {
            return new SuppliesDb
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
