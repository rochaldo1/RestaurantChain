namespace RestaurantChain.Infrastructure.Entities.Views;

/// <summary>
/// Сушность расширенная для Продаж
/// </summary>
internal class SalesDbView : SalesDb
{
    /// <summary>
    /// Имя ресторана
    /// </summary>
    public string RestaurantName { set; get; }
    
    /// <summary>
    /// Группа Id
    /// </summary>
    public int GroupId { set; get; }
    
    /// <summary>
    /// Имя блюда
    /// </summary>
    public string DishName { set; get; }
    
    /// <summary>
    /// Имя группы блюд
    /// </summary>
    public string GroupName { set; get; }
    
    /// <summary>
    /// Сумма
    /// </summary>
    public decimal SumPrice { set; get; }
}