using System.Windows;
using System.Windows.Controls;

using Microsoft.Extensions.DependencyInjection;

using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Classes;
using RestaurantChain.Presentation.Classes.Helpers;
using RestaurantChain.Presentation.View.BanksViews;
using RestaurantChain.Presentation.View.DishesViews;
using RestaurantChain.Presentation.View.GroupsOfDishesViews;
using RestaurantChain.Presentation.View.ProductsViews;
using RestaurantChain.Presentation.View.Reports;
using RestaurantChain.Presentation.View.RestaurantsViews;
using RestaurantChain.Presentation.View.Roles;
using RestaurantChain.Presentation.View.StreetsViews;
using RestaurantChain.Presentation.View.SuppliersViews;
using RestaurantChain.Presentation.View.SuppliesViews;
using RestaurantChain.Presentation.View.UnitsViews;
using RestaurantChain.Presentation.View.Users;

using Menu = RestaurantChain.Domain.Models.Menu;

namespace RestaurantChain.Presentation.View;

/// <summary>
///     Логика взаимодействия для MainWindow.xaml
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
        mainView.Content = new Welcome();
    }

    private void BuildMainMenu()
    {
        IReadOnlyCollection<UserRoleRight> menu = _menuService.List(CurrentState.CurrentUser.Id);
        CurrentState.Menu = menu;

        foreach (UserRoleRight menuItem in menu.Where(x => x.ParentId == null && x.IsMain))
        {
            if (menuItem.R == false)
            {
                //Нет прав на просмотр
                continue;
            }

            MenuItem menuItemCtl = CreateItemMenu(menuItem);

            RecursiveBuildMainMenu(menuItem.Childrens, menuItemCtl);
            menuControl.Items.Add(menuItemCtl);
        }
    }

    private void RecursiveBuildMainMenu(IReadOnlyCollection<UserRoleRight> menu, MenuItem parentMenuItem)
    {
        foreach (UserRoleRight menuItem in menu.Where(x => x.IsMain))
        {
            if (menuItem.R == false)
            {
                //Нет прав на просмотр
                continue;
            }

            MenuItem menuItemCtl = CreateItemMenu(menuItem);

            RecursiveBuildMainMenu(menuItem.Childrens, menuItemCtl);

            parentMenuItem.Items.Add(menuItemCtl);
        }
    }

    private MenuItem CreateItemMenu(UserRoleRight menu)
    {
        var menuItem = new MenuItem
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
        object? tag = ((MenuItem)sender).Tag;

        switch (tag)
        {
            case "Products":
                mainView.Content = new ProductsListWindow(_serviceProvider);

                break;
            case "Supplies":
                mainView.Content = new SuppliesWindow(_serviceProvider);

                break;
            case "Restaurants":
                mainView.Content = new RestaurantsListWindow(_serviceProvider);

                break;
            case "GetRestaurantSumByPeriods":
                WindowHelper.ShowDialog(new GetRestaurantSumByPeriodsWindow(_serviceProvider), "Выручка по ресторанам", width: 450);

                break;
            case "GetDishesSumByPeriod":
                WindowHelper.ShowDialog(new GetDishesSumByPeriodWindow(_serviceProvider), "Выручка по группам блюд", width: 450);

                break;
            case "ChangePassword":
                new ChangePasswordWindow(_serviceProvider).ShowDialog();

                break;
            case "Users":
                mainView.Content = new UserListWindow(_serviceProvider);

                break;
            case "Roles":
                mainView.Content = new RolesWindow(_serviceProvider);

                break;
            case "RoleRights":
                mainView.Content = new RoleRightsWindow(_serviceProvider);

                break;
            case "Queries":
                mainView.Content = new QueriesWindow(_serviceProvider, "Select 1 as q");

                break;
            case "Dishes":
                mainView.Content = new DishesListWindow(_serviceProvider);

                break;
            case "Streets":
                mainView.Content = new StreetsListWindow(_serviceProvider);

                break;
            case "Banks":
                mainView.Content = new BanksListWindow(_serviceProvider);

                break;
            case "DishesGroups":
                mainView.Content = new GroupsOfDishesListWindow(_serviceProvider);

                break;
            case "Suppliers":
                mainView.Content = new SuppliersListWindow(_serviceProvider);

                break;
            case "Units":
                mainView.Content = new UnitsListWindow(_serviceProvider);

                break;
            case "DocHelp":
                mainView.Content = new WebBrowser
                {
                    Source = IconHelper.GetHelpUri()
                };
                CurrentState.MainWindow.Title = "Сеть ресторанов - Справка - Содержание";

                break;
            case "About":
                new AboutProgramWindow().ShowDialog();

                return;
        }
    }
}