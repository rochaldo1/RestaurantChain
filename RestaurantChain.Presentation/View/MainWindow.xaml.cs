using RestaurantChain.DomainServices.Contracts;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

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
            var view = new StreetsViews.StreetWindow(_serviceProvider, null);
            var window = new Window
            {
                Content = view
            };
            window.ShowDialog();
            if (view.IsSuccess)
            {
                MessageBox.Show("Улица добавлена");
            }
        }

        private void GroupsOfDishes_Click(object sender, RoutedEventArgs e)
        {
            var view = new GroupsOfDishesViews.GroupOfDishesWindow(_serviceProvider, null);
            var window = new Window
            {
                Content = view
            };
            window.ShowDialog();
            if (view.IsSuccess)
            {
                MessageBox.Show("Группа добавлена");
            }
        }

        private void Banks_Click(object sender, RoutedEventArgs e)
        {
            var view = new BanksViews.BankWindow(_serviceProvider, null);
            var window = new Window
            {
                Content = view
            };
            window.ShowDialog();
            if (view.IsSuccess)
            {
                MessageBox.Show("Банк добавлен");
            }
        }

        private void Units_Click(object sender, RoutedEventArgs e)
        {
            var view = new UnitsViews.UnitWindow(_serviceProvider, null);
            var window = new Window
            {
                Content = view
            };
            window.ShowDialog();
            if (view.IsSuccess)
            {
                MessageBox.Show("Единица измерения добавлена");
            }
        }

        private void Content_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
