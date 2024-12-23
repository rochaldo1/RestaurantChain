using System.Windows.Controls;

using RestaurantChain.Presentation.ViewModel.ApplicationsForDistributionViewModel;

namespace RestaurantChain.Presentation.View.RestaurantsViews.ApplicationsForDistributionViews;

/// <summary>
/// Логика взаимодействия для ApplicationsWindow.xaml
/// </summary>
public partial class ApplicationsWindow : UserControl
{
    public ApplicationsWindow(IServiceProvider serviceProvider, int restaurantId)
    {
        InitializeComponent();
        DataContext = new ApplicationsListViewModel(serviceProvider, restaurantId);
    }
}