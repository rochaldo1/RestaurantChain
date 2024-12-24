using System.Windows.Controls;

using RestaurantChain.Presentation.Classes;
using RestaurantChain.Presentation.ViewModel.UsersViewModels.Roles;

namespace RestaurantChain.Presentation.View.Roles;

public partial class RolesWindow : UserControl
{
    public RolesWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new RolesListViewModel(serviceProvider);
        CurrentState.MainWindow.Title = "Сеть ресторанов - Настройки - Роли";
    }
}