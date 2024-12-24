using RestaurantChain.Domain.Models;
using RestaurantChain.Presentation.View;

namespace RestaurantChain.Presentation.Classes;

public static class CurrentState
{
    public static Users CurrentUser { get; set; }
    public static IReadOnlyCollection<Menu> Menu { get; set; }
    public static MainWindow MainWindow { get; set; }
}