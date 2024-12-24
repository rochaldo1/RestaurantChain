using RestaurantChain.Domain.Models.Base;

namespace RestaurantChain.Infrastructure.Entities;

public sealed class RolesDb : IdentityBase
{
    public string Name { get; set; }
}