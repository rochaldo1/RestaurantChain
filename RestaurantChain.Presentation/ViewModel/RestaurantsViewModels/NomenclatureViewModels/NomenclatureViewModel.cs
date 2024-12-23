using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.NomenclatureViewModels;

internal sealed class NomenclatureViewModel : EditViewModelBase
{
    private readonly int _restaurantId;

    public NomenclatureViewModel(IServiceProvider serviceProvider, int restaurantId, int? currentId) : base(currentId)
    {
        _restaurantId = restaurantId;
    }

    public override bool Validate()
    {
        throw new NotImplementedException();
    }
}