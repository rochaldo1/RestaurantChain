using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Entities;

namespace RestaurantChain.Infrastructure.Converters
{
    internal static class UnitsConverter
    {
        public static Units ToDomain(this UnitsDb unit)
        {
            return new Units
            {
                Id = unit.Id,
                UnitName = unit.UnitName
            };
        }

        public static UnitsDb ToStorage(this Units unit)
        {
            return new UnitsDb
            {
                Id = unit.Id,
                UnitName = unit.UnitName
            };
        }
    }
}
