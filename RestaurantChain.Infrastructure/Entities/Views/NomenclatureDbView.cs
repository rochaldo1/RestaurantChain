namespace RestaurantChain.Infrastructure.Entities.Views;

/// <summary>
/// Сушность расширенная для меню ресторана
/// </summary>
internal class NomenclatureDbView : NomenclatureDb
{
    /// <summary>
    /// Имя Ресторана
    /// </summary>
    public string RestaurantName { set; get; }
    
    /// <summary>
    /// Имя блюда
    /// </summary>
    public string DishName { set; get; }
    
    /// <summary>
    /// Id группы блюд
    /// </summary>
    public int GroupId { set; get; }
    
    /// <summary>
    /// Имя группы блюд
    /// </summary>
    public string GroupName { set; get; }
    
    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { set; get; }
}