using RestaurantChain.Domain.Models;
using RestaurantChain.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Conventors
{
    internal static class ProductsConvertor
    {
        public static ProductsDomain ToDomain(this Products product)
        {
            return new ProductsDomain
            {
                Id = product.Id,
                UnitId = product.UnitId,
                ProductName = product.ProductName,
                Quantity = product.Quantity,
                Price = product.Price
            };
        }

        public static Products ToStorage(this ProductsDomain product)
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
    }
}
