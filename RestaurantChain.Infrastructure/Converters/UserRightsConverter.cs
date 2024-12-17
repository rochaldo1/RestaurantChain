using RestaurantChain.Domain.Models;
using RestaurantChain.Infrastructure.Entities;

namespace RestaurantChain.Infrastructure.Converters
{
    internal static class UserRightsConverter
    {
        public static UserRights ToDomain(this UserRightsDb userRights)
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

        public static UserRightsDb ToStorage(this UserRights userRights)
        {
            return new UserRightsDb
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
