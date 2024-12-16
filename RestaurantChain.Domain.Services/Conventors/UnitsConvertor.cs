using RestaurantChain.Domain.Models;
using RestaurantChain.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Conventors
{
    internal static class UnitsConvertor
    {
        public static UnitsDomain ToDomain(this Units unit)
        {
            return new UnitsDomain
            {
                Id = unit.Id,
                UnitName = unit.UnitName
            };
        }

        public static Units ToStorage(this UnitsDomain unit)
        {
            return new Units
            {
                Id = unit.Id,
                UnitName = unit.UnitName
            };
        }
    }
}
