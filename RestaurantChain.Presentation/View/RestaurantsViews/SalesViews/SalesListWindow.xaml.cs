using System.Windows.Controls;

using RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.SalesViewModels;

namespace RestaurantChain.Presentation.View.RestaurantsViews.SalesViews;

public partial class SalesListWindow : UserControl
{
    public SalesListWindow(IServiceProvider serviceProvider, int restaurantId)
    {
        InitializeComponent();
        DataContext = new SalesListViewModel(serviceProvider, restaurantId);
    }
}