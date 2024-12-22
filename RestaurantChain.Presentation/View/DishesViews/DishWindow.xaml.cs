using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.DishesViewModel;
using System.Windows;
using System.Windows.Controls;

namespace RestaurantChain.Presentation.View.DishesViews;

/// <summary>
/// Логика взаимодействия для DishWindow.xaml
/// </summary>
public partial class DishWindow : UserControl
{
    /// <summary>
    /// Результат сохранения данных.
    /// </summary>
    public bool IsSuccess { private set; get; }

    public DishWindow(IServiceProvider serviceProvider, int? dishId)
    {
        var dishesService = serviceProvider.GetRequiredService<IDishesService>();
        var groupsOfDishesService = serviceProvider.GetRequiredService<IGroupsOfDishesService>();
        InitializeComponent();
        DataContext = new DishViewModel(dishesService, groupsOfDishesService, dishId);
        if (DataContext is DishViewModel dishViewModel)
        {
            dishViewModel.OnSaveSuccess += SaveSuccess;
            dishViewModel.OnCancel += SaveError;
        }
    }

    private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
    {
        ((Window)Parent).Close();
    }

    public void SaveSuccess()
    {
        IsSuccess = true;
        ((Window)Parent).Close();
    }

    public void SaveError()
    {
        IsSuccess = false;
        ((Window)Parent).Close();
    }
}