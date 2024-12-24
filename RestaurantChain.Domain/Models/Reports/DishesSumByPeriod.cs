namespace RestaurantChain.Domain.Models.Reports;

public sealed class DishesSumByPeriod
{
    public string GroupName { get; set; }
    public string DishName { set; get; }
    public DateTime Date { get; set; }
    public decimal Price { get; set; }
    public int SaleCount { get; set; }
    public string RestaurantName { set; get; }
}