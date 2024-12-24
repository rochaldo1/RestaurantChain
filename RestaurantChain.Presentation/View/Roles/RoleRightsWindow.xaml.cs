using System.Windows.Controls;

using RestaurantChain.Presentation.Classes;
using RestaurantChain.Presentation.ViewModel.UsersViewModels.RoleRights;

namespace RestaurantChain.Presentation.View.Roles;

public partial class RoleRightsWindow : UserControl
{
    public RoleRightsWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new RoleRightsListViewModel(serviceProvider);
        CurrentState.MainWindow.Title = "Сеть ресторанов - Настройки - Роли - Права";
    }
}