using RestaurantChain.Domain.Models;

namespace RestaurantChain.DomainServices.Contracts;

public interface IBanksService
{
    Banks Get(int id);
    int Create(Banks bank);
    void Update(Banks bank);
    void Delete(int id);
    IReadOnlyCollection<Banks> List();
}