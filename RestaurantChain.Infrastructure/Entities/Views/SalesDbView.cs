namespace RestaurantChain.Infrastructure.Entities.Views;

internal class SalesDbView : SalesDb
{
    public string RestaurantName { set; get; }
    public int GroupId { set; get; }
    public string DishName { set; get; }
    public string GroupName { set; get; }
    public decimal SumPrice { set; get; }
}