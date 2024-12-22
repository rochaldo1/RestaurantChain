using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;

namespace RestaurantChain.Infrastructure.Converters;

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

    public static UserRightsView ToDomain(this UserRightsDbView userRights)
    {
        return new UserRightsView
        {
            Id = userRights.Id,
            UserID = userRights.UserID,
            ItemId = userRights.ItemId,
            R = userRights.R,
            W = userRights.W,
            E = userRights.E,
            D = userRights.D,
            ItemName = userRights.ItemName,
            UserName = userRights.UserName
        };
    }
}