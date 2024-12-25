namespace RestaurantChain.Domain.Models.Reports;

/// <summary>
/// Модель для подсчета выручки ресторана за период
/// </summary>
public sealed class RestaurantSumByPeriod
{
    /// <summary>
    /// Ресторан
    /// </summary>
    public string RestaurantName { get; set; }
    
    /// <summary>
    /// Дата продажи
    /// </summary>
    public DateTime Date { get; set; }
    
    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Количество продаж
    /// </summary>
    public int SaleCount { get; set; }
}