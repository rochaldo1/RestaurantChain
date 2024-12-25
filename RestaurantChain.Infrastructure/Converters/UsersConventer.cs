using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;

namespace RestaurantChain.Infrastructure.Converters;

/// <summary>
/// Конвертер моделей для пользователей
/// </summary>
internal static class UsersConventer
{
    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
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

    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
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