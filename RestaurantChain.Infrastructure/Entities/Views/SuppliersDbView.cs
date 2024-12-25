namespace RestaurantChain.Infrastructure.Entities.Views;

internal sealed class SuppliersDbView : SuppliersDb
{
    /// <summary>
    /// Имя улицы
    /// </summary>
    public string StreetName { get; set; }
    
    /// <summary>
    /// Имя банка
    /// </summary>
    public string BankName { get; set; }
}