using RestaurantChain.Domain.Models.Base;

namespace RestaurantChain.Domain.Models;

/// <summary>
/// Права роли
/// </summary>
public class RolesRights : IdentityBase
{
    /// <summary>
    /// Id роли
    /// </summary>
    public int RoleId { get; set; }
    
    /// <summary>
    /// ID меню
    /// </summary>
    public int MenuId { get; set; }
    
    /// <summary>
    /// Права на чтение
    /// </summary>
    public bool R { set; get; }
    
    /// <summary>
    /// Права на запист
    /// </summary>
    public bool W { set; get; }
    
    /// <summary>
    /// Права на редактирование
    /// </summary>
    public bool E { set; get; }
    
    /// <summary>
    /// Права на удаление
    /// </summary>
    public bool D { set; get; }
}