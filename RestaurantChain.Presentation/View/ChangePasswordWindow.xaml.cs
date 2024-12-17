using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace RestaurantChain.Presentation.View
{
    /// <summary>
    /// Логика взаимодействия для ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow(IUsersService usersService)
        {
            InitializeComponent();

            DataContext = new ChangePasswordViewModel(usersService);
            if (DataContext is ChangePasswordViewModel changePasswordViewModel)
            {
                changePasswordViewModel.OnChangePasswordSuccess += ChangePasswordSuccess;
            }
        }

        public void ChangePasswordSuccess()
        {
            MessageBox.Show("Пароль успешно сменён!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PasswordBox_NewPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((ChangePasswordViewModel)this.DataContext).NewPassword = ((PasswordBox)sender).SecurePassword;
            }
        }

        private void PasswordBox_OldPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((ChangePasswordViewModel)this.DataContext).OldPassword = ((PasswordBox)sender).SecurePassword;
            }
        }

        private void PasswordBox_VerificationPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((ChangePasswordViewModel)this.DataContext).VerificationPassword = ((PasswordBox)sender).SecurePassword;
            }
        }
    }
}
