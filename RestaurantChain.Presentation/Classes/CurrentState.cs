using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.Presentation.View;

namespace RestaurantChain.Presentation.Classes;

/// <summary>
/// Текущее состояние пользователя
/// </summary>
public static class CurrentState
{
    /// <summary>
    /// Текущий пользрватель - грузится при авторизации
    /// </summary>
    public static Users CurrentUser { get; set; }
    
    /// <summary>
    /// Меню для текущего пользователя
    /// </summary>
    public static IReadOnlyCollection<UserRoleRight> Menu { get; set; }
    
    /// <summary>
    /// Ссылка на главное окно, чтоб менять ему заголовок из любого слоя View
    /// </summary>
    public static MainWindow MainWindow { get; set; }
}