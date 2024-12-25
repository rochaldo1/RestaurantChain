namespace RestaurantChain.Domain.Models.View;

/// <summary>
/// Права роли
/// </summary>
public sealed class RolesRightsView : RolesRights
{
    /// <summary>
    /// Имя роли
    /// </summary>
    public string RoleName { get; set; }

    /// <summary>
    /// Имя меню
    /// </summary>
    public string MenuName { get; set; }
}