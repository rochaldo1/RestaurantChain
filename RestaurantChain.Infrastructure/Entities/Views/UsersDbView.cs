namespace RestaurantChain.Infrastructure.Entities.Views;

internal sealed class UsersDbView : UsersDb
{
    /// <summary>
    /// Имя роли
    /// </summary>
    public string RoleName { get; set; }
}