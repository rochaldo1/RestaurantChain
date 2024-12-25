namespace RestaurantChain.Domain.Models.View;

/// <summary>
/// Пользователь
/// </summary>
public sealed class UsersView : Users
{
    /// <summary>
    /// Имя роли
    /// </summary>
    public string RoleName { get; set; }
}