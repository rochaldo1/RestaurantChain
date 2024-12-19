using RestaurantChain.Domain.Models;

namespace RestaurantChain.Repository.Repositories
{
    public interface IBanksRepository : IRepositoryBase<Banks>
    {
        Banks Get(string bankName);
        IReadOnlyCollection<Banks> List();
    }
}
