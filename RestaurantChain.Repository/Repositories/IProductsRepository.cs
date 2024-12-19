using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Repository.Repositories
{
    public interface IProductsRepository : IRepositoryBase<Products>
    {
        Products Get(string name);
        IReadOnlyCollection<ProductsView> List();
    }
}
