﻿using RestaurantChain.Domain.Models;
using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.DomainServices.Contracts;

public interface ISuppliesService
{
    IReadOnlyCollection<SuppliesView> List(int? supplierId, DateTime? from, DateTime? to);
    int Create(Supplies supply);
    void Update(Supplies supply);
    void Delete(int id);
    SuppliesView Get(int id);
}