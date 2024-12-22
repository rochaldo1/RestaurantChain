using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Repository;

namespace RestaurantChain.DomainServices.Services;

internal class DishesService : IDishesService
{
    private readonly IUnitOfWork _unitOfWork;

    public DishesService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public int Create(Dishes dish)
    {
        Dishes? existDish = _unitOfWork.DishesRepository.Get(dish.DishName);

        if (existDish != null)
        {
            return 0;
        }
        return _unitOfWork.DishesRepository.Create(dish);
    }

    public void Delete(int id)
    {
        _unitOfWork.DishesRepository.Delete(id);
    }

    public Dishes Get(int id)
    {
        return _unitOfWork.DishesRepository.Get(id);
    }

    public IReadOnlyCollection<DishesView> List()
    {
        return _unitOfWork.DishesRepository.List();
    }

    public void Update(Dishes dish)
    {
        Dishes? existDish = _unitOfWork.DishesRepository.Get(dish.Id);

        if (existDish == null)
        {
            throw new Exception($"Блюда с Id {dish.Id} не найдено");
        }

        _unitOfWork.DishesRepository.Update(dish);
    }
}