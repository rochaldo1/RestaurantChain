using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.ApplicationsForDistributionViewModel;

internal class ApplicationViewModel : EditViewModelBase
{
    public ApplicationViewModel(int? currentId) : base(currentId)
    {

    }

    public override bool Validate()
    {
        throw new NotImplementedException();
    }
}