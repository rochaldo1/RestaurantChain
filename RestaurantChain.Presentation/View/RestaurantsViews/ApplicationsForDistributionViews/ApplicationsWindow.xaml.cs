using RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.ApplicationsForDistributionViewModel;
using System.Windows.Controls;


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