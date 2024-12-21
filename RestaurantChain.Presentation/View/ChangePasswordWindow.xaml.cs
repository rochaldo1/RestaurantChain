using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Microsoft.Extensions.DependencyInjection;

using RestaurantChain.Presentation.ViewModel.UnitsViewModel;

namespace RestaurantChain.Presentation.View
{
    /// <summary>
    /// Логика взаимодействия для ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        private readonly IServiceProvider _serviceProvider;
        
        public ChangePasswordWindow(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();

            var userService = _serviceProvider.GetRequiredService<IUsersService>();
            DataContext = new ChangePasswordViewModel(userService);
            if (DataContext is ChangePasswordViewModel changePasswordViewModel)
            {
                changePasswordViewModel.OnChangePasswordSuccess += ChangePasswordSuccess;
            }
            PreviewKeyDown += PreviewKeyDownHandle;
        }

        public void ChangePasswordSuccess()
        {
            MessageBox.Show("Пароль успешно сменён!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
        
        private void PreviewKeyDownHandle(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    Close();

                    break;
                case Key.Enter:
                    (DataContext as ChangePasswordViewModel)?.Enter(this);

                    break;
            }
        }
    }
}
