using System.Windows.Controls;
using RestaurantChain.Presentation.Classes;
using RestaurantChain.Presentation.ViewModel.SuppliersViewModel;

namespace RestaurantChain.Presentation.View.SuppliersViews;

/// <summary>
/// Логика взаимодействия для SuppliersListWindow.xaml
/// </summary>
public partial class SuppliersListWindow : UserControl
{
    public SuppliersListWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new SupplierListViewModel(serviceProvider);
        CurrentState.MainWindow.Title = "Сеть ресторанов - Справочники - Поставщики";
    }
}