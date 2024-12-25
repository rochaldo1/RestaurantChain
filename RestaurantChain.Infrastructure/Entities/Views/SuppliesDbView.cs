namespace RestaurantChain.Infrastructure.Entities.Views;

/// <summary>
/// Сушность расширенная для поставок
/// </summary>
internal class SuppliesDbView : SuppliesDb
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