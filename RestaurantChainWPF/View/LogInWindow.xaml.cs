using RestaurantChain.Domain.Services;
using RestaurantChain.Storage;
using RestaurantChainWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RestaurantChainWPF.View
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
