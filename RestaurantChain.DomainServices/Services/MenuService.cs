using RestaurantChain.Domain.Models;
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

    public IReadOnlyCollection<Menu> List(int userId)
    {
        var menuTree = _unitOfWork.MenuRepository.List();
        var rights = _unitOfWork.UserRightsRepository.List(userId);
        SetRights(menuTree, rights);

        return menuTree;
    }

    private void SetRights(IReadOnlyCollection<Menu> menuList, IReadOnlyCollection<UserRights> rights)
    {
        foreach (var menu in menuList)
        {
            var right = rights.FirstOrDefault(x => x.ItemId == menu.Id);
            if (right != null)
            {
                menu.D = right.D;
                menu.R = right.R;
                menu.E = right.E;
                menu.W = right.W;
            }

            SetRights(menu.Childrens, rights);
        }
    }
}