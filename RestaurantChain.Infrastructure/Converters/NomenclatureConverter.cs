using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Entities;

namespace RestaurantChain.Infrastructure.Converters
{
    internal static class NomenclatureConverter
    {
        public static Nomenclature ToDomain(this NomenclatureDb nomenclature)
        {
            return new Nomenclature
            {
                Id = nomenclature.Id,
                RestaurantId = nomenclature.RestaurantId,
                DishId = nomenclature.DishId
            };
        }

        public static NomenclatureDb ToStorage(this Nomenclature nomenclature)
        {
            return new NomenclatureDb
            {
                Id = nomenclature.Id,
                RestaurantId = nomenclature.RestaurantId,
                DishId = nomenclature.DishId
            };
        }
    }
}
