namespace RestaurantChain.Domain.Models.View;

/// <summary>
/// Доступнсть в ресторанах
/// </summary>
public class AvailibilityInRestaurantView : AvailibilityInRestaurant
{
    /// <summary>
    /// Имя ресторана
    /// </summary>
    public string RestaurantName { get; set; }
    
    /// <summary>
    /// Имя единицы измерения
    /// </summary>
    public string UnitName { set; get; }
    
    /// <summary>
    /// Имя продукта
    /// </summary>
    public string ProductName { set; get; }
    
    /// <summary>
    /// Сумма продажи
    /// </summary>
    public decimal SumPrice { set; get; }
}