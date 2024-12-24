using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Repository;

namespace RestaurantChain.DomainServices.Services;

internal sealed class RolesService : IRolesService
{
    private readonly IUnitOfWork _unitOfWork;

    public RolesService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public int Create(Roles role)
    {
        return _unitOfWork.RolesRepository.Create(role);
    }

    public void Delete(int id)
    {
        _unitOfWork.RolesRepository.Delete(id);
    }

    public Roles Get(int id)
    {
        return _unitOfWork.RolesRepository.Get(id);
    }

    public IReadOnlyCollection<Roles> List()
    {
        return _unitOfWork.RolesRepository.List();
    }

    public void Update(Roles role)
    {
        _unitOfWork.RolesRepository.Update(role);
    }

    public int CreateRight(RolesRights rolesRights)
    {
        return _unitOfWork.RolesRightsRepository.Create(rolesRights);
    }

    public void DeleteRight(int id)
    {
        _unitOfWork.RolesRightsRepository.Delete(id);
    }

    public RolesRights GetRight(int id)
    {
        return _unitOfWork.RolesRightsRepository.Get(id);
    }

    public IReadOnlyCollection<RolesRightsView> ListRights(int roleId)
    {
        return _unitOfWork.RolesRightsRepository.List(roleId);
    }

    public void UpdateRight(RolesRights rolesRights)
    {
        _unitOfWork.RolesRightsRepository.Update(rolesRights);
    }
}