using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Repository;

namespace RestaurantChain.DomainServices.Services;

internal sealed class UsersService : IUsersService
{
    private readonly IUnitOfWork _unitOfWork;

    public UsersService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public bool ChangePassword(Users user)
    {
        var userExist = _unitOfWork.UsersRepository.Get(user.Id);
        if (userExist == null)
        {
            return false;
        }

        _unitOfWork.UsersRepository.Update(user);
        return true;
    }

    public Users Get(string login, string password)
    {
        var user = _unitOfWork.UsersRepository.Get(login, password);

        return user;
    }

    public Users Get(int id)
    {
        var user = _unitOfWork.UsersRepository.Get(id);

        return user;
    }

    public int Registration(Users user)
    {
        var userExist = _unitOfWork.UsersRepository.Get(user.Login);
        if (userExist != null)
        {
            return 0;
        }
        var userId = _unitOfWork.UsersRepository.Create(user);
        _unitOfWork.UserRightsRepository.CreateDefaultRights(userId);
        return userId;
    }

    public UserRights GetUserRights(int id)
    {
        return _unitOfWork.UserRightsRepository.Get(id);
    }

    public void UpdateUserRights(UserRights userRights)
    { 
        _unitOfWork.UserRightsRepository.Update(userRights);
    }

    public IReadOnlyCollection<Users> List()
    {
        return _unitOfWork.UsersRepository.List();
    }

    public IReadOnlyCollection<UserRightsView> ListUserRights(int userId)
    {
        return _unitOfWork.UserRightsRepository.List(userId);
    }

    public void Delete(int id)
    {
        _unitOfWork.UserRightsRepository.DeleteByUserId(id);
        _unitOfWork.UsersRepository.Delete(id);
    }
}