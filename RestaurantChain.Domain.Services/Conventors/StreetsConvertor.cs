using RestaurantChain.Domain.Models;
using RestaurantChain.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Conventors
{
    internal static class StreetsConvertor
    {
        public static StreetsDomain ToDomain(this Streets street)
        {
            return new StreetsDomain
            {
                Id = street.Id,
                StreetName = street.StreetName
            };
        }

        public static Streets ToStorage(this StreetsDomain street)
        {
            return new Streets
            {
                Id = street.Id,
                StreetName = street.StreetName
            };
        }
    }
}
