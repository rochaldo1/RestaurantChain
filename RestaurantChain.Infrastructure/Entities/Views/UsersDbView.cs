namespace RestaurantChain.Infrastructure.Entities.Views;

/// <summary>
/// Сушность расширенная для пользователя
/// </summary>
internal sealed class UsersDbView : UsersDb
{
    /// <summary>
    /// Имя роли
    /// </summary>
    public string RoleName { get; set; }
}