using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Presentation.View;

namespace RestaurantChain.Presentation.Classes;

public static class CurrentState
{
    public static Users CurrentUser { get; set; }
    public static IReadOnlyCollection<UserRoleRight> Menu { get; set; }
    public static MainWindow MainWindow { get; set; }
}