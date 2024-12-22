using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Repository.Repositories;

public interface ISalesRepository : IRepositoryBase<Sales>
{
    IReadOnlyCollection<SalesView> List(int? restaurantId, DateTime? from, DateTime? to);
    SalesView GetView(int id);
}