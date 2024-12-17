using RestaurantChain.Presentation.Commands;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

using RestaurantChain.DomainServices.Contracts;

namespace RestaurantChain.Presentation.ViewModel
{
    public class LogInViewModel : INotifyPropertyChanged
    {
        private string _login;
        private SecureString _password;
        private string _keyboardLayout;
        private string _capsLockStatus;
        private readonly IUsersService _userService;

        private DispatcherTimer _timerForWindow = new();
        public Action OnLogInSuccess;

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

        public LogInViewModel(IUsersService userService)
        {
            _userService = userService;
            EnterCommand = new RelayCommand(Enter);
            StartTimer(100);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
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
            // TODO: добавить смену версии из assembly
            _timerForWindow.Start();
            _timerForWindow.Tick += TimerTick;
        }
        private void Enter(object sender)
        {
            string password = new System.Net.NetworkCredential(string.Empty, _password).Password;
            var user = _userService.Get(Login, password);
            if (user is null)
            {
                MessageBox.Show("Неправильный логин или пароль!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            OnLogInSuccess?.Invoke();
        }

        public ICommand EnterCommand { get; set; }
    }
}
