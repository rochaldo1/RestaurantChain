namespace RestaurantChain.Infrastructure.Entities.Views;

internal class UserRightsDbView : UserRightsDb
{
    public string UserName { set; get; }
    public string ItemName { set; get; }
}