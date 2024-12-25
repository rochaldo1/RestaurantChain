using RestaurantChain.Infrastructure.Entities.Base;

namespace RestaurantChain.Infrastructure.Entities;

internal sealed class RolesDb : IdentityBaseDb
{
    /// <summary>
    /// Имя роли
    /// </summary>
    public string Name { get; set; }
}