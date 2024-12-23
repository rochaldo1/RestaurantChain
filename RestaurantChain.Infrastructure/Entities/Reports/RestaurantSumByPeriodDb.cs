namespace RestaurantChain.Infrastructure.Entities.Reports;

internal sealed class RestaurantSumByPeriodDb
{
    public string RestaurantName { get; set; }
    public DateTime Date { get; set; }
    public decimal Price { get; set; }
    public int SaleCount { get; set; }
}