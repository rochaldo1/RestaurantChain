using RestaurantChain.Presentation.Classes;

using System.Windows;
using System.Windows.Controls;

using RestaurantChain.Domain.Models.View;

namespace RestaurantChain.Presentation.View.RestaurantsViews;

/// <summary>
/// Interaction logic for RestaurantTabsWindow.xaml
/// </summary>
public partial class RestaurantTabsWindow : UserControl
{
    private readonly IServiceProvider _serviceProvider;
    private readonly int _restaurantId;

    public RestaurantTabsWindow(IServiceProvider serviceProvider, int restaurantId)
    {
        _restaurantId = restaurantId;
        _serviceProvider = serviceProvider;
        InitializeComponent();
        BuildMainMenu();
    }

    private void BuildMainMenu()
    {
        var menu = CurrentState.Menu.First(x => x.Id == 23);

        foreach (var menuItem in menu.Childrens)
        {
            if (menuItem.R == false)
            {
                //Нет прав на просмотр
                continue;
            }

            var menuItemCtl = CreateItemMenu(menuItem);

            menuControl.Items.Add(menuItemCtl);
        }
            
        OpenView(menu.Childrens.First().MethodName);
    }

    private MenuItem CreateItemMenu(UserRoleRight menu)
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
        var tag = ((MenuItem)sender).Tag.ToString();
        OpenView(tag);
    }

    private void OpenView(string tag)
    {
        mainView.Content = tag switch
        {
            "available" => new AvailibilityInRestaurantViews.AvailibilityInRestaurantListWindow(_serviceProvider, _restaurantId),
            "Sales" => new SalesViews.SalesListWindow(_serviceProvider, _restaurantId),
            "menu" => new NomenclatureViews.NomenclatureListWindow(_serviceProvider, _restaurantId),
            "orders" => new ApplicationsForDistributionViews.ApplicationsWindow(_serviceProvider, _restaurantId),
            _ => mainView.Content
        };
    }
}