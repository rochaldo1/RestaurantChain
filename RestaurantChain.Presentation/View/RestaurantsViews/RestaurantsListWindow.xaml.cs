using RestaurantChain.Presentation.ViewModel.RestaurantsViewModels;
using System.Windows.Controls;

namespace RestaurantChain.Presentation.View.RestaurantsViews;

/// <summary>
/// Логика взаимодействия для RestaurantsListWindow.xaml
/// </summary>
public partial class RestaurantsListWindow : UserControl
{
    public RestaurantsListWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new RestaurantListViewModel(serviceProvider);
    }
}