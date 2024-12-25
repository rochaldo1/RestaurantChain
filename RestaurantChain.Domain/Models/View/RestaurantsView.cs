namespace RestaurantChain.Domain.Models.View;

/// <summary>
/// Ресторан
/// </summary>
public class RestaurantsView : Restaurants
{
    /// <summary>
    /// Имя улицы
    /// </summary>
    public string StreetName { get; set; }
}