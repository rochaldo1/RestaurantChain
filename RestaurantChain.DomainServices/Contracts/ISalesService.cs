using RestaurantChain.Domain.Models.View;
using RestaurantChain.Domain.Models;

namespace RestaurantChain.DomainServices.Contracts;

public interface ISalesService
{
    IReadOnlyCollection<SalesView> List(int? restaurantId, DateTime? from, DateTime? to);
    int Create(Sales sales);
    void Update(Sales sales);
    void Delete(int id);
    Sales Get(int id);
    SalesView GetView(int id);
}