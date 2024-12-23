using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Repository;
using System.Data;

namespace RestaurantChain.DomainServices.Services;

internal class QueryService : IQueryService
{
    private readonly IUnitOfWork _unitOfWork;

    public QueryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public DataTable ExecuteQuery(string query)
    {
        return _unitOfWork.QueryRepository.GetResult(query);
    }
}