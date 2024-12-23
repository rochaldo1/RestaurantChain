using RestaurantChain.Presentation.ViewModel.AvailibilityInRestaurantViewModel;
using System.Windows.Controls;

namespace RestaurantChain.Presentation.View.AvailibilityInRestaurantViews;

/// <summary>
/// Логика взаимодействия для AvailibilityInRestaurantListWindow.xaml
/// </summary>
public partial class AvailibilityInRestaurantListWindow : UserControl
{
    public AvailibilityInRestaurantListWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new AvailibilityListViewModel(serviceProvider);
    }
}