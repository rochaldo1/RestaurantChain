using RestaurantChain.Presentation.Classes;
using RestaurantChain.Presentation.ViewModel.GroupsOfDishesViewModel;
using System.Windows.Controls;

namespace RestaurantChain.Presentation.View.GroupsOfDishesViews;

/// <summary>
/// Логика взаимодействия для GroupsOfDishesListWindow.xaml
/// </summary>
public partial class GroupsOfDishesListWindow : UserControl
{
    public GroupsOfDishesListWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new GroupOfDishesListViewModel(serviceProvider);
        CurrentState.MainWindow.Title = "Сеть ресторанов - Справочники - Группы блюд";
    }
}