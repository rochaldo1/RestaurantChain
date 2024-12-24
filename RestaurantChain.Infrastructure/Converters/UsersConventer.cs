using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;

namespace RestaurantChain.Infrastructure.Converters;

internal static class UsersConventer
{
    public static Users ToDomain(this UsersDb user)
    {
        return new Users
        {
            Id = user.Id,
            Login = user.Login,
            Password = user.Password,
            FirstName = user.FirstName,
            LastName = user.LastName,
            MiddleName = user.MiddleName,
            RoleId = user.RoleId,
            JobTitle = user.JobTitle
        };
    }

    public static UsersDb ToStorage(this Users user)
    {
        return new UsersDb
        {
            Id = user.Id,
            Login = user.Login,
            Password = user.Password,
            FirstName = user.FirstName,
            LastName = user.LastName,
            MiddleName = user.MiddleName,
            RoleId = user.RoleId,
            JobTitle = user.JobTitle
        };
    }

    public static UsersView ToDomain(this UsersDbView user)
    {
        return new UsersView
        {
            Id = user.Id,
            Login = user.Login,
            Password = user.Password,
            FirstName = user.FirstName,
            LastName = user.LastName,
            MiddleName = user.MiddleName,
            RoleId = user.RoleId,
            RoleName = user.RoleName,
            JobTitle = user.JobTitle
        };
    }
}