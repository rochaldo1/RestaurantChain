using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Entities;

namespace RestaurantChain.Infrastructure.Converters
{
    internal static class StreetsConverter
    {
        public static Streets ToDomain(this StreetsDb street)
        {
            return new Streets
            {
                Id = street.Id,
                StreetName = street.StreetName
            };
        }

        public static StreetsDb ToStorage(this Streets street)
        {
            return new StreetsDb
            {
                Id = street.Id,
                StreetName = street.StreetName
            };
        }
    }
}
