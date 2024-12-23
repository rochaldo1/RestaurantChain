using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.SalesViewModels;

internal sealed class SalesViewModel: EditViewModelBase
{
    private readonly ISalesService _salesService;

    private readonly int _restaurantId;

    public SalesViewModel(IServiceProvider serviceProvider, int restaurantId, int? currentId) : base(currentId)
    {
        _restaurantId = restaurantId;
    }

    public override bool Validate()
    {
        throw new NotImplementedException();
    }
}