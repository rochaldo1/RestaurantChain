using RestaurantChain.Presentation.ViewModel.UnitsViewModel;
using System.Windows.Controls;

namespace RestaurantChain.Presentation.View.UnitsViews;

/// <summary>
/// Логика взаимодействия для UnitsListWindow.xaml
/// </summary>
public partial class UnitsListWindow : UserControl
{
    public UnitsListWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new UnitListViewModel(serviceProvider);
    }
}