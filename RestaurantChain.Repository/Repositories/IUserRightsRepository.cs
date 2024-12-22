using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Repository.Repositories;

public interface IUserRightsRepository : IRepositoryBase<UserRights>
{
    IReadOnlyCollection<UserRightsView> List(int userId);
    UserRightsView GetView(int id);
    void CreateDefaultRights(int userId);
    void DeleteByUserId(int userId);
}