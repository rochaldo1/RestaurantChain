using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Entities;

namespace RestaurantChain.Infrastructure.Converters
{
    internal static class SalesConverter
    {
        public static Sales ToDomain(this SalesDb sale)
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

        public static SalesDb ToStorage(this Sales sale)
        {
            return new SalesDb
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
