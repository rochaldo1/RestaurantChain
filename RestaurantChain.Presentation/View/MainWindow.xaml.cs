using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Classes;

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
        foreach (var menuItem in menu.Where(x => x.ParentId == null))
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
        foreach (var menuItem in menu)
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
        var tag = ((MenuItem)sender).Tag;
        switch (tag)
        {
            case "Other":
                break;
            case "Products":
                {
                    var view = new ProductsViews.ProductsListWindow(_serviceProvider);
                    mainView.Content = view;
                }
                break;
            case "Supplies":
                {
                    var view = new SuppliesViews.SuppliesWindow(_serviceProvider);
                    mainView.Content = view;
                }
                break;
            case "Restaurants":
                break;
            case "Sales":
                break;
            case "References":
                break;
            case "Doc":
                break;
            case "Help":
                break;
            case "ChangePassword":
                {
                    ChangePasswordWindow changePasswordWindow = new(_serviceProvider);
                    changePasswordWindow.ShowDialog();
                }
                break;
            case "Setings":
                break;
            case "Users":
                break;
            case "UserRights":
                break;
            case "Queries":
                {
                    var view = new QueriesWindow(_serviceProvider);
                    mainView.Content = view;
                }
                break;
            case "Dishes":
                {
                    var view = new DishesViews.DishesListWindow(_serviceProvider);
                    mainView.Content = view;
                }
                break;
            case "Streets":
                {
                    var view = new StreetsViews.StreetsListWindow(_serviceProvider);
                    mainView.Content = view;
                }
                break;
            case "Banks":
                {
                    var view = new BanksViews.BanksListWindow(_serviceProvider);
                    mainView.Content = view;
                }
                break;
            case "DishesGroups":
                {
                    var view = new GroupsOfDishesViews.GroupsOfDishesListWindow(_serviceProvider);
                    mainView.Content = view;
                }
                break;
            case "Suppliers":
                {
                    var view = new SuppliersViews.SuppliersListWindow(_serviceProvider);
                    mainView.Content = view;
                }
                break;
            case "Units":
                {
                    var view = new UnitsViews.UnitsListWindow(_serviceProvider);
                    mainView.Content = view;
                }
                break;
            case "DocRevenue":
                break;
            case "DocHelp":
                break;
            case "About":
                AboutProgramWindow aboutProgramWindow = new();
                aboutProgramWindow.ShowDialog();
                break;
            default:
                throw new Exception("Меню {} не найдено");
        }
    }
}