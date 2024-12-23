namespace RestaurantChain.Domain.Models.Reports;

public sealed class RestaurantSumByPeriod
{
    public string RestaurantName { get; set; }
    public DateTime Date { get; set; }
    public decimal Price { get; set; }
    public int SaleCount { get; set; }
}