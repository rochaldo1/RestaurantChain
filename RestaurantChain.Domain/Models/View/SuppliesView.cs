namespace RestaurantChain.Domain.Models.View;

public class SuppliesView : Supplies
{
    public string SupplierName { get; set; }
    public string UnitName { set; get; }
    public string ProductName { set; get; }
    public decimal SumPrice { set; get; }
}