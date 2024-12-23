using System.Windows.Controls;

using RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.NomenclatureViewModels;

namespace RestaurantChain.Presentation.View.RestaurantsViews.NomenclatureViews;

public partial class NomenclatureWindow : UserControl
{
    public NomenclatureWindow(IServiceProvider serviceProvider, int restaurantId, int? nomenclatureId)
    {
        InitializeComponent();
        DataContext = new NomenclatureViewModel(serviceProvider, restaurantId, nomenclatureId);
    }
}