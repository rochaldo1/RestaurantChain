namespace RestaurantChain.Infrastructure.Entities.Views;

public sealed class RolesRightsDbView : RolesRightsDb
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