namespace RestaurantChain.Domain.Models.View;

/// <summary>
/// Поставка
/// </summary>
public class SuppliesView : Supplies
{
    /// <summary>
    /// Имя поставщика
    /// </summary>
    public string SupplierName { get; set; }
    
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