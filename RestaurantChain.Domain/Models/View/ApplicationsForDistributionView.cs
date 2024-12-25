namespace RestaurantChain.Domain.Models.View;

/// <summary>
/// Заявка на распределение
/// </summary>
public class ApplicationsForDistributionView : ApplicationsForDistribution
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
    /// Сумма
    /// </summary>
    public decimal SumPrice { set; get; }
}