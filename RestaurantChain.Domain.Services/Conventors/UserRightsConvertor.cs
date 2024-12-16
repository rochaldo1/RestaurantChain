using RestaurantChain.Domain.Models;
using RestaurantChain.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Conventors
{
    internal static class UserRightsConvertor
    {
        public static UserRightsDomain ToDomain(this UserRights userRights)
        {
            return new UserRightsDomain
            {
                Id = userRights.Id,
                UserID = userRights.UserID,
                ItemId = userRights.ItemId,
                R = userRights.R,
                W = userRights.W,
                E = userRights.E,
                D = userRights.D
            };
        }

        public static UserRights ToStorage(this UserRightsDomain userRights)
        {
            return new UserRights
            {
                Id = userRights.Id,
                UserID = userRights.UserID,
                ItemId = userRights.ItemId,
                R = userRights.R,
                W = userRights.W,
                E = userRights.E,
                D = userRights.D
            };
        }
    }
}
