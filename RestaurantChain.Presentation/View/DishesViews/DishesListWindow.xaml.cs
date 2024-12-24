using RestaurantChain.Presentation.Classes;
using RestaurantChain.Presentation.ViewModel.DishesViewModel;
using System.Windows.Controls;

namespace RestaurantChain.Presentation.View.DishesViews;

/// <summary>
/// Логика взаимодействия для DishesListWindow.xaml
/// </summary>
public partial class DishesListWindow : UserControl
{
    public DishesListWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new DishListViewModel(serviceProvider);
        CurrentState.MainWindow.Title = "Сеть ресторанов - Блюда";
    }
}