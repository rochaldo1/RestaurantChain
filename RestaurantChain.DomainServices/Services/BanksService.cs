using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Repository;

namespace RestaurantChain.DomainServices.Services;

internal class BanksService : IBanksService
{
    private readonly IUnitOfWork _unitOfWork;

    public BanksService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public int Create(Banks bank)
    {
        Banks? existBank = _unitOfWork.BanksRepository.Get(bank.BankName);

        if (existBank != null)
        {
            return 0;
        }

        return _unitOfWork.BanksRepository.Create(bank);
    }

    public void Delete(int id)
    {
        _unitOfWork.BanksRepository.Delete(id);
    }

    public Banks Get(int id)
    {
        return _unitOfWork.BanksRepository.Get(id);
    }

    public IReadOnlyCollection<Banks> List()
    {
        return _unitOfWork.BanksRepository.List();
    }

    public void Update(Banks bank)
    {
        Banks? existBank = _unitOfWork.BanksRepository.Get(bank.Id);

        if (existBank == null)
        {
            throw new Exception($"Банка с Id {bank.Id} не найдено");
        }

        _unitOfWork.BanksRepository.Update(bank);
    }
}