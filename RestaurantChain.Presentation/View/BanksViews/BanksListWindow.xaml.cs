using RestaurantChain.Presentation.ViewModel.BanksViewModel;
using System.Windows.Controls;

using RestaurantChain.Presentation.Classes;

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
        CurrentState.MainWindow.Title = "Сеть ресторанов - Справочники - Банки";
    }
}