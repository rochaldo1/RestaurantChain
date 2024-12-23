using System.Windows.Controls;

using RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.AvailibilityInRestaurantViewModel;

namespace RestaurantChain.Presentation.View.RestaurantsViews.AvailibilityInRestaurantViews;

/// <summary>
/// Логика взаимодействия для AvailibilityInRestaurantListWindow.xaml
/// </summary>
public partial class AvailibilityInRestaurantListWindow : UserControl
{
    public AvailibilityInRestaurantListWindow(IServiceProvider serviceProvider, int restaurantId)
    {
        InitializeComponent();
        DataContext = new AvailibilityListViewModel(serviceProvider, restaurantId);
    }
}