using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Repository.Repositories;

public interface INomenclatureRepository : IRepositoryBase<Nomenclature>
{
    IReadOnlyCollection<NomenclatureView> List(int restaurantId);
    NomenclatureView GetView(int restaurantId);
}