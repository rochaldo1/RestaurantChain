namespace RestaurantChain.Domain.Models.View;

/// <summary>
/// Блюдо
/// </summary>
public sealed class DishesView : Dishes
{
    /// <summary>
    /// Имя группы блюд
    /// </summary>
    public string GroupName { get; set; }
}