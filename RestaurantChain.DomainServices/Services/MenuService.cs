using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Repository;

namespace RestaurantChain.DomainServices.Services;

internal class MenuService : IMenuService
{
    private readonly IUnitOfWork _unitOfWork;

    public MenuService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IReadOnlyCollection<Menu> List()
    {
        return _unitOfWork.MenuRepository.List();
    }

    public IReadOnlyCollection<UserRoleRight> List(int userId)
    {
        return _unitOfWork.RolesRightsRepository.ListUserRoleRights(userId);
    }
}