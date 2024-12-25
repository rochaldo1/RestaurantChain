namespace RestaurantChain.Domain.Models.View;

/// <summary>
/// Меню блюда
/// </summary>
public class NomenclatureView : Nomenclature
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