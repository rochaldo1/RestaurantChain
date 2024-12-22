﻿using RestaurantChain.Domain.Models;

namespace RestaurantChain.DomainServices.Contracts;

public interface IStreetsService
{
    Streets Get(int id);
    int Create(Streets street);
    void Update(Streets street);
    void Delete(int id);
    IReadOnlyCollection<Streets> List();
}