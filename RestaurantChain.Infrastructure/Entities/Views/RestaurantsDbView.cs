namespace RestaurantChain.Infrastructure.Entities.Views;

/// <summary>
/// Сушность расширенная для ресторана
/// </summary>
internal class RestaurantsDbView : RestaurantsDb
{
    /// <summary>
    /// Имя улицы
    /// </summary>
    public string StreetName { get; set; }
}