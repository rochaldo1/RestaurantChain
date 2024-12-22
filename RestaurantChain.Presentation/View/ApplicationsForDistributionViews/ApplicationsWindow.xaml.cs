using RestaurantChain.Presentation.ViewModel.ApplicationsForDistributionViewModel;
using RestaurantChain.Presentation.ViewModel.SuppliesViewModel;
using System.Windows.Controls;

namespace RestaurantChain.Presentation.View.ApplicationsForDistributionViews;

/// <summary>
/// Логика взаимодействия для ApplicationsWindow.xaml
/// </summary>
public partial class ApplicationsWindow : UserControl
{
    public ApplicationsWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new ApplicationsListViewModel(serviceProvider);
    }
}