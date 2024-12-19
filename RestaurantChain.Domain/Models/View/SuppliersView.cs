namespace RestaurantChain.Domain.Models.View;

public sealed class SuppliersView : Suppliers
{
    public string StreetName { get; set; }
    public string BankName { get; set; }
}