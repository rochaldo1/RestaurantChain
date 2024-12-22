using System.Windows.Controls;
using RestaurantChain.Presentation.ViewModel.UsersViewModels.Users;

namespace RestaurantChain.Presentation.View.Users;

/// <summary>
/// Interaction logic for UserListWindow.xaml
/// </summary>
public partial class UserListWindow : UserControl
{
    public UserListWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new UsersListViewModel(serviceProvider);
    }
}