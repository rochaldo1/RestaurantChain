using RestaurantChain.Domain.Models;

namespace RestaurantChain.DomainServices.Contracts;

public interface IUnitsService
{
    Units Get(int id);
    int Create(Units unit);
    void Update(Units unit);
    void Delete(int id);
    IReadOnlyCollection<Units> List();
}