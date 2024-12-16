using RestaurantChain.Domain.Models;
using RestaurantChain.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Conventors
{
    internal static class AvailibilityInRestaurantConvertor
    {
        public static AvailibilityInRestaurantDomain ToDomain(AvailibilityInRestaurant availibility)
        {
            return new AvailibilityInRestaurantDomain
            {
                Id = availibility.Id,
                RestaurantId = availibility.RestaurantId,
                ProductId = availibility.ProductId,
                UnitId = availibility.UnitId,
                Quantity = availibility.Quantity,
                Price = availibility.Price
            };
        }

        public static AvailibilityInRestaurant ToStorage(AvailibilityInRestaurantDomain availibility)
        {
            return new AvailibilityInRestaurant
            {
                Id = availibility.Id,
                RestaurantId = availibility.RestaurantId,
                ProductId = availibility.ProductId,
                UnitId = availibility.UnitId,
                Quantity = availibility.Quantity,
                Price = availibility.Price
            };
        }
    }
}
