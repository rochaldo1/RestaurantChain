namespace RestaurantChain.Infrastructure.Entities.Views;

/// <summary>
/// Сушность расширенная для блюд
/// </summary>
internal sealed class DishesDbView : DishesDb
{
    /// <summary>
    /// Имя группы блюд
    /// </summary>
    public string GroupName { get; set; }
}