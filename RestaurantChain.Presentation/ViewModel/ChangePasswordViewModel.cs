using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using System.Security;
using System.Windows.Input;
using System.Windows;
using System.Windows.Threading;
using System.Text.RegularExpressions;
using RestaurantChain.Presentation.Classes;

namespace RestaurantChain.Presentation.ViewModel;

public class ChangePasswordViewModel : ViewModelBase
{
    private SecureString _newPassword;
    private SecureString _oldPassword;
    private SecureString _verificationPassword;
    private string _keyboardLayout;
    private string _capsLockStatus;

    private DispatcherTimer _timerForWindow = new();
    private readonly IUsersService _userService;

    public Action OnChangePasswordSuccess;

    public SecureString NewPassword
    {
        get => _newPassword;
        set
        {
            _newPassword = value;
            OnPropertyChanged("NewPassword");
        }
    }

    public SecureString OldPassword
    {
        get => _oldPassword;
        set
        {
            _oldPassword = value;
            OnPropertyChanged("OldPassword");
        }
    }

    public SecureString VerificationPassword
    {
        get => _verificationPassword;
        set
        {
            _verificationPassword = value;
            OnPropertyChanged("VerificationPassword");
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

    public ChangePasswordViewModel(IUsersService userService)
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
            CapsLockStatusText = "Клавиша CapsLock нажата";
        else
            CapsLockStatusText = "";

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
        string oldPassword = new System.Net.NetworkCredential(string.Empty, _oldPassword).Password;

        if (string.IsNullOrWhiteSpace(oldPassword))
        {
            MessageBox.Show("Введите старый пароль!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        string newPassword = new System.Net.NetworkCredential(string.Empty, _newPassword).Password;

        if (string.IsNullOrWhiteSpace(newPassword))
        {
            MessageBox.Show("Введите новый пароль!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        var pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{4,15}$";
        var r = new Regex(pattern);

        if (!r.IsMatch(newPassword))
        {
            MessageBox.Show("Пароль должен быть от 4 до 15 символов, содержать цифры, прописные и заглавные буквы латинского алфавита!",
                "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        string verificationPassword = new System.Net.NetworkCredential(string.Empty, _verificationPassword).Password;

        if (string.IsNullOrWhiteSpace(verificationPassword))
        {
            MessageBox.Show("Введите проверочный пароль!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (newPassword != verificationPassword)
        {
            MessageBox.Show("Пароли не совпадают!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (newPassword == oldPassword)
        {
            MessageBox.Show("Старый и новый пароли совпадают!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        var user = _userService.Get(CurrentState.CurrentUser.Login, oldPassword);
        if (user is null)
        {
            MessageBox.Show("Неправильный старый пароль!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        user.Password = newPassword;
        if (!_userService.ChangePassword(user))
        {
            MessageBox.Show("ОШИБКА!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        OnChangePasswordSuccess?.Invoke();
    }

    public ICommand EnterCommand { get; set; }
}