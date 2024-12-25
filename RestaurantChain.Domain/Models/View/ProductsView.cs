namespace RestaurantChain.Domain.Models.View;

public sealed class ProductsView : Products
{
    /// <summary>
    /// Имя единицы измерения
    /// </summary>
    public string UnitName { set; get; }
}