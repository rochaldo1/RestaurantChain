using RestaurantChain.Domain.Models;
using RestaurantChain.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Conventors
{
    internal static class NomenclatureConvertor
    {
        public static NomenclatureDomain ToDomain(this Nomenclature nomenclature)
        {
            return new NomenclatureDomain
            {
                Id = nomenclature.Id,
                RestaurantId = nomenclature.RestaurantId,
                DishId = nomenclature.DishId
            };
        }

        public static Nomenclature ToStorage(this NomenclatureDomain nomenclature)
        {
            return new Nomenclature
            {
                Id = nomenclature.Id,
                RestaurantId = nomenclature.RestaurantId,
                DishId = nomenclature.DishId
            };
        }
    }
}
