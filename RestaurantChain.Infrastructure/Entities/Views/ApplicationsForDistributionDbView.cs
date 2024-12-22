namespace RestaurantChain.Infrastructure.Entities.Views;

internal class ApplicationsForDistributionDbView : ApplicationsForDistributionDb
{
    public string RestaurantName { get; set; }
    public string UnitName { set; get; }
    public string ProductName { set; get; }
    public decimal SumPrice { set; get; }
}