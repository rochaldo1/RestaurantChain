namespace RestaurantChain.Infrastructure.Entities.Views;

internal class AvailibilityInRestaurantDbView : AvailibilityInRestaurantDb
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