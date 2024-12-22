namespace RestaurantChain.Domain.Models.View;

public class ApplicationsForDistributionView : ApplicationsForDistribution
{
    public string RestaurantName { get; set; }
    public string UnitName { set; get; }
    public string ProductName { set; get; }
    public decimal SumPrice { set; get; }
}