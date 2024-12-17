using RestaurantChain.Presentation.ViewModel;

using System.Windows;
using System.Windows.Controls;

using RestaurantChain.DomainServices.Contracts;

namespace RestaurantChain.Presentation.View
{
    /// <summary>
    /// Логика взаимодействия для LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {        
        public LogInWindow(IUsersService usersService)
        {
            InitializeComponent();

            DataContext = new LogInViewModel(usersService);
            if (DataContext is LogInViewModel loginViewModel)
            {
                loginViewModel.OnLogInSuccess += LogInSuccess;
            }
        }
        
        public void LogInSuccess()
        {
            MainWindow window = new();
            window.Show();
            Close();
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
    }
}
