namespace RestaurantChain.Domain.Models.View;

public class AvailibilityInRestaurantView : AvailibilityInRestaurant
{
    public string RestaurantName { get; set; }
    public string UnitName { set; get; }
    public string ProductName { set; get; }
}