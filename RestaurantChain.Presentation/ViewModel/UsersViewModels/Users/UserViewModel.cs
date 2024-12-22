using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.ViewModel.Base;
using System.Net;
using System.Security;
using System.Text.RegularExpressions;
using System.Windows;

namespace RestaurantChain.Presentation.ViewModel.UsersViewModels.Users;

internal class UserViewModel : EditViewModelBase
{
    private readonly IUsersService _usersService;

    private string _login;
    private SecureString _password;
    private SecureString _verificationPassword;

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


    public UserViewModel(IUsersService usersService, int? currentId) : base(currentId)
    {
        _usersService = usersService;

        if (!Validate())
        {
            OnCancel?.Invoke();
        }

        EnterCommand = new RelayCommand(Enter);
    }

    private Domain.Models.Users ValidateAndGetModel()
    {
        if (string.IsNullOrWhiteSpace(Login))
        {
            MessageBox.Show("Введите логин!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        var password = new NetworkCredential(string.Empty, _password).Password;
        var verificationPassword = new NetworkCredential(string.Empty, _verificationPassword).Password;

        if (!CurrentId.HasValue || CurrentId.HasValue && !string.IsNullOrWhiteSpace(password))
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите пароль!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

                return null;
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

                return null;
            }

            if (string.IsNullOrWhiteSpace(verificationPassword))
            {
                MessageBox.Show("Введите проверочный пароль!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

                return null;
            }

            if (password != verificationPassword)
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

                return null;
            }
        }

        var user = new Domain.Models.Users
        {
            Password = password,
            Login = Login
        };

        if (CurrentId.HasValue)
        {
            user.Id = CurrentId.Value;
        }

        return user;
    }

    public void Enter(object sender)
    {
        var user = ValidateAndGetModel();
        if (user == null)
        {
            return;
        }

        // Сохранить или обновить.
        var result = CurrentId.HasValue ? Update(user) : Create(user);

        if (result) // Если успех - закрыть окно.
        {
            OnSaveSuccess?.Invoke();
        }
    }

    /// <summary>
    /// Действие обновить.
    /// </summary>
    /// <returns>Успех операции.</returns>
    private bool Update(Domain.Models.Users user)
    {
        if (!_usersService.ChangePassword(user))
        {
            MessageBox.Show("ОШИБКА!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        return true;
    }

    /// <summary>
    /// Действие создать.
    /// </summary>
    /// <returns>Успех операции.</returns>
    private bool Create(Domain.Models.Users user)
    {
        var userId = _usersService.Registration(user);
        if (userId == 0)
        {
            MessageBox.Show("Такой пользователь уже существует!", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);

            return false;
        }
        return true;
    }

    public override bool Validate()
    {
        if (CurrentId.HasValue)
        {
            var user = _usersService.Get(CurrentId.Value);

            if (user == null)
            {
                MessageBox.Show("Такой улицы не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            Login = user.Login;

            return true;
        }

        return true;
    }
}