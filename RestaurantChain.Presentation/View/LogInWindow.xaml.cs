using RestaurantChain.Presentation.ViewModel;

using System.Windows;
using System.Windows.Controls;

using RestaurantChain.DomainServices.Contracts;
using System.Reflection;
using System.Windows.Input;

using Microsoft.Extensions.DependencyInjection;

namespace RestaurantChain.Presentation.View;

/// <summary>
/// Логика взаимодействия для LogInWindow.xaml
/// </summary>
public partial class LogInWindow : Window
{
    private readonly IServiceProvider _serviceProvider;

    public LogInWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;
        var usersService = serviceProvider.GetRequiredService<IUsersService>();

        DataContext = new LogInViewModel(usersService);
        if (DataContext is LogInViewModel loginViewModel)
        {
            loginViewModel.OnLogInSuccess += LogInSuccess;
        }
        PreviewKeyDown += PreviewKeyDownHandle;
    }
        
    public void LogInSuccess()
    {
        MainWindow window = new(_serviceProvider);
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
        RegistrationWindow registrationWindow = new(_serviceProvider);
        registrationWindow.Owner = this;
        registrationWindow.ShowDialog();
    }
        
    private void PreviewKeyDownHandle(object sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Escape:
                Close();

                break;
            case Key.Enter:
                (DataContext as LogInViewModel)?.Enter(this);

                break;
        }
    }
}