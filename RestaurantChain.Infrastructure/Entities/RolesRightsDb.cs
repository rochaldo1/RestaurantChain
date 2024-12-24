using RestaurantChain.Domain.Models.Base;

namespace RestaurantChain.Infrastructure.Entities;

public class RolesRightsDb : IdentityBase
{
    public int RoleId { get; set; }
    public int MenuId { get; set; }
    public bool R { set; get; }
    public bool W { set; get; }
    public bool E { set; get; }
    public bool D { set; get; }
}