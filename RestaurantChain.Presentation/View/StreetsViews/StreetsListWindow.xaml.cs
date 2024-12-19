using System.Windows;
using System.Windows.Controls;

using Microsoft.Extensions.DependencyInjection;

using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.StreetsViewModel;

namespace RestaurantChain.Presentation.View.StreetsViews;

/// <summary>
///     Логика взаимодействия для StreetsListWindow.xaml
/// </summary>
public partial class StreetsListWindow : UserControl
{
    public StreetsListWindow(IServiceProvider serviceProvider)
    {
        DataContext = new StreetListViewModel(serviceProvider);
        InitializeComponent();
    }
}