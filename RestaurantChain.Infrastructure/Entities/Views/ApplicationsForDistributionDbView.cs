namespace RestaurantChain.Infrastructure.Entities.Views;

internal class ApplicationsForDistributionDbView : ApplicationsForDistributionDb
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