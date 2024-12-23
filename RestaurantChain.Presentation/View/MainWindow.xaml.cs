using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Classes;
using RestaurantChain.Presentation.Classes.Helpers;
using RestaurantChain.Presentation.View.Users;

namespace RestaurantChain.Presentation.View;

/// <summary>
/// Логика взаимодействия для MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IMenuService _menuService;

    public MainWindow(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _menuService = serviceProvider.GetRequiredService<IMenuService>();
        InitializeComponent();
        BuildMainMenu();
    }

    private void BuildMainMenu()
    {
        var menu = _menuService.List(CurrentState.CurrentUser.Id);
        CurrentState.Menu = menu;
        foreach (var menuItem in menu.Where(x => x.ParentId == null && x.IsMain == true))
        {
            if (menuItem.R == false)
            {
                //Нет прав на просмотр
                continue;
            }

            var menuItemCtl = CreateItemMenu(menuItem);

            RecursiveBuildMainMenu(menuItem.Childrens, menuItemCtl);
            menuControl.Items.Add(menuItemCtl);
        }
    }

    private void RecursiveBuildMainMenu(IReadOnlyCollection<Domain.Models.Menu> menu, MenuItem parentMenuItem)
    {
        foreach (var menuItem in menu.Where(x=> x.IsMain == true))
        {
            if (menuItem.R == false)
            { 
                //Нет прав на просмотр
                continue;
            }

            var menuItemCtl = CreateItemMenu(menuItem);

            RecursiveBuildMainMenu(menuItem.Childrens, menuItemCtl);

            parentMenuItem.Items.Add(menuItemCtl);
        }

    }

    private MenuItem CreateItemMenu(Domain.Models.Menu menu)
    {
        MenuItem menuItem = new MenuItem
        {
            Header = menu.ItemName,
            Tag = menu.MethodName,
            Style = Resources["MenuItemStyle"] as Style
        };

        menuItem.Click += MenuItem_Click;

        return menuItem;
    }

    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
        var tag = ((MenuItem) sender).Tag;
        switch (tag)
        {
            case "Other":
                break;
            case "Products":
                mainView.Content = new ProductsViews.ProductsListWindow(_serviceProvider);
                break;
            case "Supplies":
                mainView.Content = new SuppliesViews.SuppliesWindow(_serviceProvider);
                break;
            case "Restaurants":
                mainView.Content = new RestaurantsViews.RestaurantsListWindow(_serviceProvider);
                break;
            case "GetRestaurantSumByPeriods":
                WindowHelper.ShowDialog(new Reports.GetRestaurantSumByPeriodsWindow(_serviceProvider), "Выручка по ресторанам");
                break;
            case "GetDishesSumByPeriod":
                WindowHelper.ShowDialog(new Reports.GetDishesSumByPeriodWindow(_serviceProvider), "Выручка по блюдам");
                break;
            case "ChangePassword":
                new ChangePasswordWindow(_serviceProvider).ShowDialog();
                break;
            case "Setings":
                break;
            case "Users":
                mainView.Content = new UserListWindow(_serviceProvider);
                break;
            case "UserRights":
                mainView.Content = new UserRightsListWindow(_serviceProvider);
                break;
            case "Queries":
                mainView.Content = new QueriesWindow(_serviceProvider, "Select 1 as q");
                break;
            case "Dishes":
                mainView.Content = new DishesViews.DishesListWindow(_serviceProvider);
                break;
            case "Streets":
                mainView.Content = new StreetsViews.StreetsListWindow(_serviceProvider);
                break;
            case "Banks":
                mainView.Content = new BanksViews.BanksListWindow(_serviceProvider);
                break;
            case "DishesGroups":
                mainView.Content = new GroupsOfDishesViews.GroupsOfDishesListWindow(_serviceProvider);
                break;
            case "Suppliers":
                mainView.Content = new SuppliersViews.SuppliersListWindow(_serviceProvider);
                break;
            case "Units":
                mainView.Content = new UnitsViews.UnitsListWindow(_serviceProvider);
                break;
            case "DocRevenue":
                break;
            case "DocHelp":
                mainView.Content = new WebBrowser
                {
                    Source = IconHelper.GetHelpUri()
                };
                break;
            case "About":
                new AboutProgramWindow().ShowDialog();
                return;
        }
    }
}