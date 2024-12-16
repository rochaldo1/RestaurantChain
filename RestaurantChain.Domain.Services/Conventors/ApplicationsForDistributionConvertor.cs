using RestaurantChain.Domain.Models;
using RestaurantChain.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Conventors
{
    internal static class ApplicationsForDistributionConvertor
    {
        public static ApplicationsForDistributionDomain ToDomain(this ApplicationsForDistribution application)
        {
            return new ApplicationsForDistributionDomain
            {
                Id = application.Id,
                RestaurantId = application.RestaurantId,
                ProductId = application.ProductId,
                UnitId = application.UnitId,
                Quantity = application.Quantity,
                Price = application.Price,
                ApplicationDate = application.ApplicationDate
            };
        }

        public static ApplicationsForDistribution ToStorage(this ApplicationsForDistributionDomain application)
        {
            return new ApplicationsForDistribution
            {
                Id = application.Id,
                RestaurantId = application.RestaurantId,
                ProductId = application.ProductId,
                UnitId = application.UnitId,
                Quantity = application.Quantity,
                Price = application.Price,
                ApplicationDate = application.ApplicationDate
            };
        }
    }
}
