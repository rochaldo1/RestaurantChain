using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Entities;

namespace RestaurantChain.Infrastructure.Converters
{
    internal static class ApplicationsForDistributionConverter
    {
        public static ApplicationsForDistribution ToDomain(this ApplicationsForDistributionDb application)
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

        public static ApplicationsForDistributionDb ToStorage(this ApplicationsForDistribution application)
        {
            return new ApplicationsForDistributionDb
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
