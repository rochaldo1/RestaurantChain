namespace RestaurantChain.Domain.Models.View;

/// <summary>
/// Поставщик
/// </summary>
public sealed class SuppliersView : Suppliers
{
    /// <summary>
    /// Имя улицы
    /// </summary>
    public string StreetName { get; set; }
    
    /// <summary>
    /// Имя банка
    /// </summary>
    public string BankName { get; set; }
}