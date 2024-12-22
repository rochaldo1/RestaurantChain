using System.Windows.Controls;
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
    }
}