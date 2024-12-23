using System.Windows.Controls;

using RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.SalesViewModels;

namespace RestaurantChain.Presentation.View.RestaurantsViews.SalesViews;

public partial class SalesWindow : UserControl
{
    public SalesWindow(IServiceProvider serviceProvider, int restaurantId, int? saleId)
    {
        InitializeComponent();
        DataContext = new SalesViewModel(serviceProvider, restaurantId, saleId);
    }
}