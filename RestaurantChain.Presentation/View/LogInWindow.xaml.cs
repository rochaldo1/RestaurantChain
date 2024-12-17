using RestaurantChain.Presentation.ViewModel;

using System.Windows;
using System.Windows.Controls;

using RestaurantChain.DomainServices.Contracts;
using System.Reflection;

namespace RestaurantChain.Presentation.View
{
    /// <summary>
    /// Логика взаимодействия для LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        private readonly IUsersService _usersService;

        public LogInWindow(IUsersService usersService)
        {
            InitializeComponent();
            _usersService = usersService;

            DataContext = new LogInViewModel(usersService);
            if (DataContext is LogInViewModel loginViewModel)
            {
                loginViewModel.OnLogInSuccess += LogInSuccess;
            }
        }
        
        public void LogInSuccess()
        {
            MainWindow window = new(_usersService);
            window.Show();
            Close();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            TextBoxVersion.Text = "Версия " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((LogInViewModel)this.DataContext).Password = ((PasswordBox)sender).SecurePassword;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Login.Text = "";
            Password.Password = "";
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new(_usersService);
            registrationWindow.Owner = this;
            registrationWindow.ShowDialog();
        }
    }
}
