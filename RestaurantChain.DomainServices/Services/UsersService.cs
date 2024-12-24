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
        Users? userExist = _unitOfWork.UsersRepository.Get(user.Id);

        if (userExist == null)
        {
            return false;
        }

        _unitOfWork.UsersRepository.Update(user);

        return true;
    }

    public Users Get(string login, string password)
    {
        Users user = _unitOfWork.UsersRepository.Get(login, password);

        return user;
    }

    public Users Get(int id)
    {
        Users user = _unitOfWork.UsersRepository.Get(id);

        return user;
    }

    public int Registration(Users user)
    {
        Users? userExist = _unitOfWork.UsersRepository.Get(user.Login);

        if (userExist != null)
        {
            return 0;
        }

        int userId = _unitOfWork.UsersRepository.Create(user);

        return userId;
    }

    public IReadOnlyCollection<UsersView> List()
    {
        return _unitOfWork.UsersRepository.List();
    }

    public void Delete(int id)
    {
        _unitOfWork.UsersRepository.Delete(id);
    }
}