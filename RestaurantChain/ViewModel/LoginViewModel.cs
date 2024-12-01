using RestaurantChain.Model.Services.LogIn;
using RestaurantChain.Model.Convertors;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;
using Timer = System.Windows.Threading.DispatcherTimer;

namespace RestaurantChain.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _login;
        private string _password;
        private string _keyboardLayout;
        private string _capsLockStatus;
        private ILogInService _logInService = new LogInService(new HashCodeConventor());

        private Timer _windowTimer;
        public Action OnLogInSuccess;

        /// <summary>
        /// Логин пользователя.
        /// </summary>
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        /// <summary>
        /// Раскладка клавиатуры.
        /// </summary>
        public string KeyboardLayout
        {
            get => _keyboardLayout;
            set
            {
                _keyboardLayout = value;
                OnPropertyChanged("KeyboardLayout");
            }
        }
        
        /// <summary>
        /// Статус клавиши CapsLock.
        /// </summary>
        public string CapsLockStatus
        {
            get => _capsLockStatus;
            set
            {
                _capsLockStatus = value;
                OnPropertyChanged("CapsLockStatus");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Обработчик изменения свойств.
        /// </summary>
        /// <param name="prop">Название свойства.</param>
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        /// <summary>
        /// Парсер языка для вывода текущей раскладки клавиатуры в окно.
        /// </summary>
        /// <param name="language">Язык.</param>
        /// <returns></returns>
        private string ParseLanguage(string language)
        {
            int startIndex = language.IndexOf('(');
            int count = language.Length - startIndex;
            language = language.Remove(startIndex, count);

            return Char.ToUpper(language[0]) + language.Substring(1);
        }

        /// <summary>
        /// Проверка статуса CapsLock и раскладки клавиатуры.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Объект, содержащий информацию о связанном событии.</param>
        private void Timer_Tick(object sender, System.EventArgs e)
        {
            if (Console.CapsLock)
                CapsLockStatus = "Клавиша CapsLock нажата";
            else CapsLockStatus = "";

            KeyboardLayout = "Язык ввода: " + ParseLanguage(InputLanguageManager.Current.CurrentInputLanguage.DisplayName);
        }

        /// <summary>
        /// Запуск таймера, который постоянно обновляет информацию о статусе CapsLock и раскладке.
        /// </summary>
        /// <param name="interval"></param>
        private void StartTimer(long interval)
        {
            _windowTimer.Interval = new System.TimeSpan(interval);
            _windowTimer.Start();
            _windowTimer.Tick += Timer_Tick;
        }
    }
}
