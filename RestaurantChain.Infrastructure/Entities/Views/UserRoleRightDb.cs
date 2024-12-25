using RestaurantChain.Domain.Models.Base;

namespace RestaurantChain.Infrastructure.Entities.Views;

internal sealed class UserRoleRightDb : IdentityBase
{
    /// <summary>
    /// Права на запись
    /// </summary>
    public bool W { set; get; }
    
    /// <summary>
    /// Права на редактирование
    /// </summary>
    public bool E { set; get; }
    
    /// <summary>
    /// Права на чтение
    /// </summary>
    public bool R { set; get; }
    
    /// <summary>
    /// Права на удаление
    /// </summary>
    public bool D { set; get; }
    
    /// <summary>
    /// Главное меню или дочернеее
    /// </summary>
    public bool IsMain { set; get; }
    
    /// <summary>
    /// Родительское меню
    /// </summary>
    public int? ParentId { set; get; }
    
    /// <summary>
    /// Имя модуля
    /// </summary>
    public string DllName { set; get; }
    
    /// <summary>
    /// Имя меню
    /// </summary>
    public string ItemName { set; get; }
    
    /// <summary>
    /// Имя функции
    /// </summary>
    public string MethodName { set; get; }
    
    /// <summary>
    /// Сортировка
    /// </summary>
    public int OrderNum { set; get; }
}