using RestaurantChain.Domain.Models;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с единицами измерения
/// </summary>
public interface IUnitsService
{
    Units Get(int id);
    int Create(Units unit);
    void Update(Units unit);
    void Delete(int id);
    IReadOnlyCollection<Units> List();
}