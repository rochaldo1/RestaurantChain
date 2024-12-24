using RestaurantChain.Domain.Models.Base;

namespace RestaurantChain.Domain.Models;

public sealed class Roles : IdentityBase
{
    public string Name { get; set; }
}