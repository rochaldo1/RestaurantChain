namespace RestaurantChain.Infrastructure.Entities.Views;

/// <summary>
/// Сушность расширенная для продукта
/// </summary>
internal sealed class ProductsDbView : ProductsDb
{
    /// <summary>
    /// Имя единицы измерения
    /// </summary>
    public string UnitName { set; get; }
}