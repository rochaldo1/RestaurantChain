using RestaurantChain.Presentation.Classes;
using RestaurantChain.Presentation.ViewModel.SuppliesViewModel;
using System.Windows.Controls;

namespace RestaurantChain.Presentation.View.SuppliesViews;

/// <summary>
/// Interaction logic for SuppliesWindow.xaml
/// </summary>
public partial class SuppliesWindow : UserControl
{
    public SuppliesWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new SuppliesListViewModel(serviceProvider);
        CurrentState.MainWindow.Title = "Сеть ресторанов - Поставки";
    }
}