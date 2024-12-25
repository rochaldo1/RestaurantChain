namespace RestaurantChain.Infrastructure.Entities.Views;

internal sealed class ProductsDbView : ProductsDb
{
    /// <summary>
    /// Имя единицы измерения
    /// </summary>
    public string UnitName { set; get; }
}