using RestaurantChain.Domain.Models;

namespace RestaurantChain.DomainServices.Contracts;

/// <summary>
/// Сервис для работы с банками
/// </summary>
public interface IBanksService
{
    Banks Get(int id);
    int Create(Banks bank);
    void Update(Banks bank);
    void Delete(int id);
    IReadOnlyCollection<Banks> List();
}