using RestaurantChain.Domain.Models.Base;

namespace RestaurantChain.Domain.Models;

/// <summary>
/// РОль
/// </summary>
public sealed class Roles : IdentityBase
{
    /// <summary>
    /// Имя роли
    /// </summary>
    public string Name { get; set; }
}