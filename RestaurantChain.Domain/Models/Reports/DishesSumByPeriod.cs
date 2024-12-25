namespace RestaurantChain.Domain.Models.Reports;

/// <summary>
/// Модель отчета по блюдам
/// </summary>
public sealed class DishesSumByPeriod
{
    /// <summary>
    /// Группа блюд
    /// </summary>
    public string GroupName { get; set; }
    
    /// <summary>
    /// Блюдо
    /// </summary>
    public string DishName { set; get; }
    
    /// <summary>
    /// Дата заказа
    /// </summary>
    public DateTime Date { get; set; }
    
    /// <summary>
    /// Стоимость
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Количество проданных блюд
    /// </summary>
    public int SaleCount { get; set; }
    
    /// <summary>
    /// Ресторан где продали 
    /// </summary>
    public string RestaurantName { set; get; }
}