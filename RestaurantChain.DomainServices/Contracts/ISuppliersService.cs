using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с поставщиками
/// </summary>
public interface ISuppliersService
{
    Suppliers Get(int id);
    int Create(Suppliers supplier);
    void Update(Suppliers supplier);
    void Delete(int id);
    IReadOnlyCollection<SuppliersView> List();
}