using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Microsoft.Extensions.DependencyInjection;

using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Classes;
using RestaurantChain.Presentation.ViewModel;

namespace RestaurantChain.Presentation.View;

/// <summary>
///     Логика взаимодействия для LogInWindow.xaml
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
        CurrentState.MainWindow = new MainWindow(_serviceProvider);
        CurrentState.MainWindow.Show();
        Close();
    }

    private void WindowLoaded(object sender, RoutedEventArgs e)
    {
        TextBoxVersion.Text = "Версия " + Assembly.GetExecutingAssembly().GetName().Version;
    }

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (DataContext != null)
        {
            ((LogInViewModel)DataContext).Password = ((PasswordBox)sender).SecurePassword;
        }
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        Login.Text = "";
        Password.Password = "";
    }

    private void Registration_Click(object sender, RoutedEventArgs e)
    {
        var registrationWindow = new RegistrationWindow(_serviceProvider);
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