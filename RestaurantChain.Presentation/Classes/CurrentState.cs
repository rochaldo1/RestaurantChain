using RestaurantChain.Domain.Models;

namespace RestaurantChain.Presentation.Classes;

public static class CurrentState
{
    public static Users CurrentUser { get; set; }
    public static IReadOnlyCollection<Menu> Menu { get; set; }
}