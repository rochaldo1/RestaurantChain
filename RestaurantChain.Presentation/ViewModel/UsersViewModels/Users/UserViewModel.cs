using System.Net;
using System.Security;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using RestaurantChain.Presentation.ViewModel.Base;

namespace RestaurantChain.Presentation.ViewModel.UsersViewModels.Users;

internal class UserViewModel : EditViewModelBase
{
    private readonly IUsersService _usersService;
    private readonly IRolesService _rolesService;

    private readonly DispatcherTimer _timerForWindow = new DispatcherTimer();

    private string _login;
    private string _firstName;
    private string _lastName;
    private string _middleName;
    private string _jobTitle;
    private int _selectedRoleId;
    private SecureString _password;
    private SecureString _verificationPassword;
    private string _keyboardLayout;
    private string _capsLockStatus;

    private IReadOnlyCollection<Domain.Models.Roles> _rolesDataSource;

    /// <summary>
    /// Модель данных. Роли
    /// </summary>
    public IReadOnlyCollection<Domain.Models.Roles> RolesDataSource
    {
        get => _rolesDataSource;
        set
        {
            _rolesDataSource = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Выбранная роль
    /// </summary>
    public int SelectedRoleId
    {
        get => _selectedRoleId;
        set
        {
            _selectedRoleId = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Фамилия
    /// </summary>
    public string LastName
    {
        get => _lastName;
        set
        {
            _lastName = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Имя
    /// </summary>
    public string FirstName
    {
        get => _firstName;
        set
        {
            _firstName = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Отчество
    /// </summary>
    public string MiddleName
    {
        get => _middleName;
        set
        {
            _middleName = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Должность
    /// </summary>
    public string JobTitle
    {
        get => _jobTitle;
        set
        {
            _jobTitle = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Логин
    /// </summary>
    public string Login
    {
        get => _login;
        set
        {
            _login = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Пароль
    /// </summary>
    public SecureString Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }
    
    /// <summary>
    /// Модель данных. Подтверждение пароля
    /// </summary>
    public SecureString VerificationPassword
    {
        get => _verificationPassword;
        set
        {
            _verificationPassword = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Текст для языка
    /// </summary>
    public string KeyboardLayoutText
    {
        get => _keyboardLayout;
        set
        {
            _keyboardLayout = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Модель данных. Текст для CapsLock
    /// </summary>
    public string CapsLockStatusText
    {
        get => _capsLockStatus;
        set
        {
            _capsLockStatus = value;
            OnPropertyChanged();
        }
    }

    public UserViewModel(IUsersService usersService, IRolesService rolesService, int? currentId) : base(currentId)
    {
        _usersService = usersService;
        _rolesService = rolesService;

        if (!Validate())
        {
            OnCancel?.Invoke();
        }

        EnterCommand = new RelayCommand(Enter);
        StartTimer(100);
    }

    /// <summary>
    /// Парсинг языка
    /// </summary>
    /// <param name="language"></param>
    /// <returns></returns>
    private string ParseLanguage(string language)
    {
        int startIndex = language.IndexOf('(');
        int count = language.Length - startIndex;
        language = language.Remove(startIndex, count);

        return char.ToUpper(language[0]) + language.Substring(1);
    }

    /// <summary>
    /// Отслеживание капслок и языка ввода
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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

    /// <summary>
    /// Старт таймера
    /// </summary>
    /// <param name="interval"></param>
    private void StartTimer(long interval)
    {
        _timerForWindow.Interval = new TimeSpan(interval);
        _timerForWindow.Start();
        _timerForWindow.Tick += TimerTick;
    }

    /// <summary>
    /// Провалидировать и получить модель для сохранения
    /// </summary>
    /// <returns></returns>
    private Domain.Models.Users ValidateAndGetModel()
    {
        if (string.IsNullOrWhiteSpace(Login))
        {
            MessageBox.Show("Введите логин!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        if (string.IsNullOrWhiteSpace(FirstName))
        {
            MessageBox.Show("Введите имя!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        if (string.IsNullOrWhiteSpace(LastName))
        {
            MessageBox.Show("Введите фамлия!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        if (string.IsNullOrWhiteSpace(MiddleName))
        {
            MessageBox.Show("Введите отчество!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        if (string.IsNullOrWhiteSpace(JobTitle))
        {
            MessageBox.Show("Введите должность!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        if (SelectedRoleId <= 0)
        {
            MessageBox.Show("Выберите роль!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

            return null;
        }

        string password = new NetworkCredential(string.Empty, _password).Password;
        string verificationPassword = new NetworkCredential(string.Empty, _verificationPassword).Password;

        if (!CurrentId.HasValue || (CurrentId.HasValue && !string.IsNullOrWhiteSpace(password)))
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
            Login = Login,
            FirstName = FirstName,
            LastName = LastName,
            MiddleName = MiddleName,
            RoleId = SelectedRoleId,
            JobTitle = JobTitle
        };

        if (CurrentId.HasValue)
        {
            user.Id = CurrentId.Value;
        }

        return user;
    }

    /// <summary>
    /// Обработка кнопки сохранить
    /// </summary>
    /// <param name="sender"></param>
    public void Enter(object sender)
    {
        Domain.Models.Users? user = ValidateAndGetModel();

        if (user == null)
        {
            return;
        }

        // Сохранить или обновить.
        bool result = CurrentId.HasValue ? Update(user) : Create(user);

        if (result) // Если успех - закрыть окно.
        {
            OnSaveSuccess?.Invoke();
        }
    }

    /// <summary>
    ///     Действие обновить.
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
    ///  Действие создать.
    /// </summary>
    /// <returns>Успех операции.</returns>
    private bool Create(Domain.Models.Users user)
    {
        int userId = _usersService.Registration(user);

        if (userId == 0)
        {
            MessageBox.Show("Такой пользователь уже существует!", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);

            return false;
        }

        return true;
    }

    /// <summary>
    /// Валидация при загрузке и заполнение полей
    /// </summary>
    /// <returns></returns>
    public override bool Validate()
    {
        RolesDataSource = _rolesService.List();

        if (CurrentId.HasValue)
        {
            Domain.Models.Users? user = _usersService.Get(CurrentId.Value);

            if (user == null)
            {
                MessageBox.Show("Такой улицы не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }

            Login = user.Login;
            LastName = user.LastName;
            MiddleName = user.MiddleName;
            FirstName = user.FirstName;
            JobTitle = user.JobTitle;
            SelectedRoleId = user.RoleId;

            return true;
        }

        return true;
    }
}