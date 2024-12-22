using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Repository.Repositories;

public interface ISuppliesRepository : IRepositoryBase<Supplies>
{
    IReadOnlyCollection<SuppliesView> List(int? supplierId, DateTime? from, DateTime? to);
    SuppliesView GetView(int id);
    int CountByProduct(int productId);
}