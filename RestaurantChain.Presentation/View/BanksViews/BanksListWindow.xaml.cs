using RestaurantChain.Presentation.ViewModel.BanksViewModel;
using System.Windows.Controls;

namespace RestaurantChain.Presentation.View.BanksViews;

/// <summary>
/// Логика взаимодействия для BanksListWindow.xaml
/// </summary>
public partial class BanksListWindow : UserControl
{
    public BanksListWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new BankListViewModel(serviceProvider);
    }
}