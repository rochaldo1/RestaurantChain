using System.Windows.Controls;
using RestaurantChain.Presentation.ViewModel.UsersViewModels.UserRights;

namespace RestaurantChain.Presentation.View.Users;

/// <summary>
/// Interaction logic for UserRightsListWindow.xaml
/// </summary>
public partial class UserRightsListWindow : UserControl
{
    public UserRightsListWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new UserRightsListViewModel(serviceProvider);
    }
}