using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel;
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

namespace RestaurantChain.Presentation.View
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow(IUsersService usersService)
        {
            InitializeComponent();

            DataContext = new RegistrationViewModel(usersService);
            if (DataContext is RegistrationViewModel registrationViewModel)
            {
                registrationViewModel.OnRegistrationSuccess += RegistrationSuccess;
            }
        }

        public void RegistrationSuccess()
        {
            MessageBox.Show("Вы успешно зарегестрировались!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((RegistrationViewModel)this.DataContext).Password = ((PasswordBox)sender).SecurePassword;
            }
        }

        private void PasswordBox_VerificationPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((RegistrationViewModel)this.DataContext).VerificationPassword = ((PasswordBox)sender).SecurePassword;
            }
        }
    }
}
