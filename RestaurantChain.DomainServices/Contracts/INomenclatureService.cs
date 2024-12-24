using RestaurantChain.Domain.Models.View;
using RestaurantChain.Domain.Models;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с меню ресторана
/// </summary>
public interface INomenclatureService
{
    Nomenclature Get(int id);
    int Create(Nomenclature nomenclature);
    void Update(Nomenclature nomenclature);
    void Delete(int id);
    IReadOnlyCollection<NomenclatureView> List(int restaurantId);
}