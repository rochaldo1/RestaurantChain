using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;

namespace RestaurantChain.Infrastructure.Converters
{
    internal static class ProductsConverter
    {
        public static Products ToDomain(this ProductsDb product)
        {
            return new Products
            {
                Id = product.Id,
                UnitId = product.UnitId,
                ProductName = product.ProductName,
                Quantity = product.Quantity,
                Price = product.Price
            };
        }

        public static ProductsDb ToStorage(this Products product)
        {
            return new ProductsDb
            {
                Id = product.Id,
                UnitId = product.UnitId,
                ProductName = product.ProductName,
                Quantity = product.Quantity,
                Price = product.Price
            };
        }

        public static ProductsView ToDomain(this ProductsDbView product)
        {
            return new ProductsView
            {
                Id = product.Id,
                UnitId = product.UnitId,
                ProductName = product.ProductName,
                Quantity = product.Quantity,
                Price = product.Price,
                UnitName = product.UnitName
            };
        }
    }
}
