namespace RestaurantChain.Infrastructure.Entities.Views;

internal sealed class UserRoleRightDb
{
    public bool W { set; get; }
    public bool E { set; get; }
    public bool R { set; get; }
    public bool D { set; get; }
    public bool IsMain { set; get; }
    public int? ParentId { set; get; }
    public int OrderNum { set; get; }
    public int Id { set; get; }
    public string DllName { set; get; }
    public string ItemName { set; get; }
    public string MethodName { set; get; }
}