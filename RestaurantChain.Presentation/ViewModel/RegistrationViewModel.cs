using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows;
using System.Text.RegularExpressions;
using RestaurantChain.Domain.Models;

namespace RestaurantChain.Presentation.ViewModel
{
    public class RegistrationViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private string _login;
        private SecureString _password;
        private SecureString _verificationPassword;
        private string _keyboardLayout;
        private string _capsLockStatus;
        private readonly IUsersService _userService;

        private DispatcherTimer _timerForWindow = new();
        public Action OnRegistrationSuccess;

        public SecureString SecurePassword { private get; set; }

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }

        public SecureString Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged("Password");
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
        private void Enter(object sender)
        {
            string password = new System.Net.NetworkCredential(string.Empty, _password).Password;

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите пароль!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{4,15}$";
            var r = new Regex(pattern);

            if (!r.IsMatch(password))
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

            if (string.IsNullOrWhiteSpace(Login))
            {
                MessageBox.Show("Введите логин!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(password != verificationPassword)
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

        public ICommand EnterCommand { get; set; }
    }
}
