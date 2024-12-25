using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Infrastructure.Entities;
using RestaurantChain.Infrastructure.Entities.Views;

namespace RestaurantChain.Infrastructure.Converters;

/// <summary>
/// Конвертер моделей для ролей и их прав
/// </summary>
internal static class RolesConverter
{
    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
    public static Roles ToDomain(this RolesDb model)
    {
        return new Roles
        {
            Id = model.Id,
            Name = model.Name
        };
    }

    /// <summary>
    /// Преобразовать доменную модель в сущность БД
    /// </summary>
    /// <returns>Сущность БД</returns>
    public static RolesDb ToStorage(this Roles model)
    {
        return new RolesDb
        {
            Id = model.Id,
            Name = model.Name
        };
    }

    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
    public static RolesRights ToDomain(this RolesRightsDb model)
    {
        return new RolesRights
        {
            Id = model.Id,
            RoleId = model.RoleId,
            D = model.D,
            MenuId = model.MenuId,
            E = model.E,
            R = model.R,
            W = model.W
        };
    }

    /// <summary>
    /// Преобразовать доменную модель в сущность БД
    /// </summary>
    /// <returns>Сущность БД</returns>
    public static RolesRightsDb ToStorage(this RolesRights model)
    {
        return new RolesRightsDb
        {
            Id = model.Id,
            RoleId = model.RoleId,
            D = model.D,
            MenuId = model.MenuId,
            E = model.E,
            R = model.R,
            W = model.W
        };
    }

    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
    public static RolesRightsView ToDomain(this RolesRightsDbView model)
    {
        return new RolesRightsView
        {
            Id = model.Id,
            RoleId = model.RoleId,
            D = model.D,
            MenuId = model.MenuId,
            E = model.E,
            R = model.R,
            W = model.W,
            MenuName = model.MenuName,
            RoleName = model.RoleName
        };
    }
    
    /// <summary>
    /// Преобразовать сущность БД в доменную модель
    /// </summary>
    /// <returns>Доменная модель</returns>
    public static UserRoleRight ToDomain(this UserRoleRightDb model)
    {
        return new UserRoleRight
        {
            Id = model.Id,
            D = model.D,
            E = model.E,
            R = model.R,
            W = model.W,
            ItemName = model.ItemName,
            DllName = model.DllName,
            MethodName = model.MethodName,
            IsMain = model.IsMain,
            ParentId = model.ParentId,
            OrderNum = model.OrderNum,
        };
    }
}