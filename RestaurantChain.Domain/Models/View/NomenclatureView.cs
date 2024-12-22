namespace RestaurantChain.Domain.Models.View;

public class NomenclatureView : Nomenclature
{
    public string RestaurantName { set; get; }
    public string DishName { set; get; }
    public int GroupId { set; get; }
    public string GroupName { set; get; }
    public decimal Price { set; get; }
}