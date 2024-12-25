namespace RestaurantChain.Infrastructure.Entities.Views;

/// <summary>
/// Сушность расширенная для прав ролей
/// </summary>
internal sealed class RolesRightsDbView : RolesRightsDb
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