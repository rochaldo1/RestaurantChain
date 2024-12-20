using System.Windows.Controls;
using RestaurantChain.Presentation.ViewModel.StreetsViewModel;

namespace RestaurantChain.Presentation.View.StreetsViews;

/// <summary>
/// Логика взаимодействия для StreetsListWindow.xaml
/// </summary>
public partial class StreetsListWindow : UserControl
{
    public StreetsListWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new StreetListViewModel(serviceProvider);
    }
}