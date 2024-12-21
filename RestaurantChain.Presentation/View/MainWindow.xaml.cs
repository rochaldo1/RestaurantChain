using RestaurantChain.DomainServices.Contracts;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Media;

namespace RestaurantChain.Presentation.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IServiceProvider _serviceProvider;

        public MainWindow(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            AboutProgramWindow aboutProgramWindow = new();
            aboutProgramWindow.ShowDialog();
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow changePasswordWindow = new(_serviceProvider);
            changePasswordWindow.ShowDialog();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Streets_Click(object sender, RoutedEventArgs e)
        {
            var view = new StreetsViews.StreetsListWindow(_serviceProvider);
            var window = new Window
            {
                Content = view,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Title = "Улицы",
                // TODO: Сделать добавление иконки database.png
            };
            window.ShowDialog();
        }

        private void GroupsOfDishes_Click(object sender, RoutedEventArgs e)
        {
            var view = new GroupsOfDishesViews.GroupsOfDishesListWindow(_serviceProvider);
            var window = new Window
            {
                Content = view,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Title = "Группы блюд",
                // TODO: Сделать добавление иконки database.png
            };
            window.ShowDialog();
        }

        private void Banks_Click(object sender, RoutedEventArgs e)
        {
            var view = new BanksViews.BanksListWindow(_serviceProvider);
            var window = new Window
            {
                Content = view,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Title = "Банки",
                // TODO: Сделать добавление иконки database.png
            };
            window.ShowDialog();
        }

        private void Units_Click(object sender, RoutedEventArgs e)
        {
            var view = new UnitsViews.UnitsListWindow(_serviceProvider);
            var window = new Window
            {
                Content = view,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Title = "Банки",
                // TODO: Сделать добавление иконки database.png
            };
            window.ShowDialog();
        }

        private void Content_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Suppliers_Click(object sender, RoutedEventArgs e)
        {
            var view = new SuppliersViews.SuppliersListWindow(_serviceProvider);
            var window = new Window
            {
                Content = view,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Title = "Поставщики",
                // TODO: Сделать добавление иконки database.png
            };
            window.ShowDialog();
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            var view = new ProductsViews.ProductsListWindow(_serviceProvider);
            var window = new Window
            {
                Content = view,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Title = "Продукты",
                // TODO: Сделать добавление иконки database.png
            };
            window.ShowDialog();
        }
    }
}
