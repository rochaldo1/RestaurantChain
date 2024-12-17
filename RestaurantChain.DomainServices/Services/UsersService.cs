using RestaurantChain.Domain.Models;
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

    public int Registration(Users user)
    {
        var userExist = _unitOfWork.UsersRepository.Get(user.Login);
        if (userExist != null)
        {
            return 0;
        }
        return _unitOfWork.UsersRepository.Create(user);
    }
}