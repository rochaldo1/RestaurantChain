using System.Net;
using System.Security;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel;

public class RegistrationViewModel : ViewModelBase
{
    private readonly IUsersService _userService;
    private string _login;
    private SecureString _password;
    private SecureString _verificationPassword;
    private string _keyboardLayout;
    private string _capsLockStatus;

    private readonly DispatcherTimer _timerForWindow = new DispatcherTimer();
    public Action OnRegistrationSuccess;

    public SecureString SecurePassword { private get; set; }

    public string Login
    {
        get => _login;
        set
        {
            _login = value;
            OnPropertyChanged();
        }
    }

    public SecureString Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }

    public SecureString VerificationPassword
    {
        get => _verificationPassword;
        set
        {
            _verificationPassword = value;
            OnPropertyChanged();
        }
    }

    public string KeyboardLayoutText
    {
        get => _keyboardLayout;
        set
        {
            _keyboardLayout = value;
            OnPropertyChanged("KeyboardLayoutText");
        }
    }

    public string CapsLockStatusText
    {
        get => _capsLockStatus;
        set
        {
            _capsLockStatus = value;
            OnPropertyChanged("CapsLockStatusText");
        }
    }

    public ICommand EnterCommand { get; set; }

    public RegistrationViewModel(IUsersService userService)
    {
        _userService = userService;
        EnterCommand = new RelayCommand(Enter);
        StartTimer(100);
    }

    private string ParseLanguage(string language)
    {
        int startIndex = language.IndexOf('(');
        int count = language.Length - startIndex;
        language = language.Remove(startIndex, count);

        return Char.ToUpper(language[0]) + language.Substring(1);
    }

    private void TimerTick(object sender, EventArgs e)
    {
        if (Console.CapsLock)
        {
            CapsLockStatusText = "Клавиша CapsLock нажата";
        }
        else
        {
            CapsLockStatusText = "";
        }

        KeyboardLayoutText = "Язык ввода " + ParseLanguage(InputLanguageManager.Current.CurrentInputLanguage.DisplayName);
    }

    private void StartTimer(long interval)
    {
        _timerForWindow.Interval = new TimeSpan(interval);
        _timerForWindow.Start();
        _timerForWindow.Tick += TimerTick;
    }

    public void Enter(object sender)
    {
        string password = new NetworkCredential(string.Empty, _password).Password;

        if (string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show("Введите пароль!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return;
        }

        var pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{4,15}$";
        var r = new Regex(pattern);

        if (!r.IsMatch(password))
        {
            MessageBox.Show(
                "Пароль должен быть от 4 до 15 символов, содержать цифры, прописные и заглавные буквы латинского алфавита!",
                "Ошибка ввода",
                MessageBoxButton.OK,
                MessageBoxImage.Error);

            return;
        }

        string verificationPassword = new NetworkCredential(string.Empty, _verificationPassword).Password;

        if (string.IsNullOrWhiteSpace(verificationPassword))
        {
            MessageBox.Show("Введите проверочный пароль!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return;
        }

        if (string.IsNullOrWhiteSpace(Login))
        {
            MessageBox.Show("Введите логин!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return;
        }

        if (password != verificationPassword)
        {
            MessageBox.Show("Пароли не совпадают!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return;
        }

        var user = new Users();
        user.Password = password;
        user.Login = Login;

        int userId = _userService.Registration(user);

        if (userId == 0)
        {
            MessageBox.Show("Такой пользователь уже существует!", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);

            return;
        }

        OnRegistrationSuccess?.Invoke();
    }
}