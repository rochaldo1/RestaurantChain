using System.Windows.Controls;
using RestaurantChain.Presentation.Classes;
using RestaurantChain.Presentation.ViewModel.RestaurantsViewModels.SalesViewModels;

namespace RestaurantChain.Presentation.View.RestaurantsViews.SalesViews;

/// <summary>
/// Логика взаимодействия для SalesListWindow.xaml
/// </summary>
public partial class SalesListWindow : UserControl
{
    public SalesListWindow(IServiceProvider serviceProvider, int restaurantId)
    {
        InitializeComponent();
        DataContext = new SalesListViewModel(serviceProvider, restaurantId);
        CurrentState.MainWindow.Title = "Сеть ресторанов - Рестораны - Продажи";
    }
}