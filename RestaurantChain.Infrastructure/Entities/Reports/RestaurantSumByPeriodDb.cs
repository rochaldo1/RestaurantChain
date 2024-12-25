namespace RestaurantChain.Infrastructure.Entities.Reports;

/// <summary>
/// Сущность отчета по ресторанам
/// </summary>
internal sealed class RestaurantSumByPeriodDb
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