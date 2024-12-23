using RestaurantChain.Domain.Models.View;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.SalesViewModels;

internal sealed class SalesListViewModel : ListViewModelBase<SalesView>
{
    private readonly int _restaurantId;

    public SalesListViewModel(IServiceProvider serviceProvider, int restaurantId) : base(serviceProvider)
    {
        _restaurantId = restaurantId;
    }

    protected override void DataBind()
    {
        throw new NotImplementedException();
    }

    protected override void SetCommands()
    {
    }
}