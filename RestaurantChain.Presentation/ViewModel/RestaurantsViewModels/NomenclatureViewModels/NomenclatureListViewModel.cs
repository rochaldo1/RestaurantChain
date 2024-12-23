using RestaurantChain.Domain.Models.View;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.NomenclatureViewModels;

internal sealed class NomenclatureListViewModel : ListViewModelBase<NomenclatureView>
{
    private readonly int _restaurantId;

    public NomenclatureListViewModel(IServiceProvider serviceProvider, int restaurantId) : base(serviceProvider)
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