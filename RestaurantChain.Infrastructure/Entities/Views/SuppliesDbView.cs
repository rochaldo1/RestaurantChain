namespace RestaurantChain.Infrastructure.Entities.Views;

internal class SuppliesDbView : SuppliesDb
{
    public string SupplierName { get; set; }
    public string UnitName { set; get; }
    public string ProductName { set; get; }
    public decimal SumPrice { set; get; }
}