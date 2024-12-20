﻿using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Repository;

namespace RestaurantChain.DomainServices.Services;

internal class StreetsService : IStreetsService
{
    private readonly IUnitOfWork _unitOfWork;

    public StreetsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public int Create(Streets street)
    {
        Streets? existStreet = _unitOfWork.StreetsRepository.Get(street.StreetName);

        if (existStreet != null)
        {
            return 0;
        }

        return _unitOfWork.StreetsRepository.Create(street);
    }

    public Streets Get(int id)
    {
        return _unitOfWork.StreetsRepository.Get(id);
    }

    public void Update(Streets street)
    {
        Streets? existStreet = _unitOfWork.StreetsRepository.Get(street.Id);

        if (existStreet == null)
        {
            throw new Exception($"Улицы с Id {street.Id} не найдено");
        }

        _unitOfWork.StreetsRepository.Update(street);
    }

    public void Delete(int id)
    {
        _unitOfWork.StreetsRepository.Delete(id);
    }

    public IReadOnlyCollection<Streets> List()
    {
        return _unitOfWork.StreetsRepository.List();
    }
}