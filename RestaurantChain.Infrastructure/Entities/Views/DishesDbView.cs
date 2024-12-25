namespace RestaurantChain.Infrastructure.Entities.Views;

internal sealed class DishesDbView : DishesDb
{
    /// <summary>
    /// Имя группы блюд
    /// </summary>
    public string GroupName { get; set; }
}