using RestaurantChain.Presentation.Classes;

using System.Windows;
using System.Windows.Controls;

namespace RestaurantChain.Presentation.View.RestaurantsViews
{
    /// <summary>
    /// Interaction logic for RestaurantTabsWindow.xaml
    /// </summary>
    public partial class RestaurantTabsWindow : UserControl
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly int _restId;

        public RestaurantTabsWindow(IServiceProvider serviceProvider, int restaurantId)
        {
            _restId = restaurantId;
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
            var tag = ((MenuItem)sender).Tag.ToString();

            switch (tag)
            {
                case "available":
                {
                    var view = new ProductsViews.ProductsListWindow(_serviceProvider);
                    mainView.Content = view;
                }

                    break;
                case "orders":
                {
                    var view = new ProductsViews.ProductsListWindow(_serviceProvider);
                    mainView.Content = view;
                }

                    break;
                case "menu":
                {
                    var view = new ProductsViews.ProductsListWindow(_serviceProvider);
                    mainView.Content = view;
                }

                    break;
            }
        }
    }
}