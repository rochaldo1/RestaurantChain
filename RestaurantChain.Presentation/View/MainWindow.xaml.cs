using RestaurantChain.DomainServices.Contracts;
using System.Windows;

namespace RestaurantChain.Presentation.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IUsersService _usersService;

        public MainWindow(IUsersService usersService)
        {
            _usersService = usersService;
            InitializeComponent();
        }

        private void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            AboutProgramWindow aboutProgramWindow = new();
            aboutProgramWindow.ShowDialog();
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow changePasswordWindow = new(_usersService);
            changePasswordWindow.ShowDialog();
        }
    }
}
