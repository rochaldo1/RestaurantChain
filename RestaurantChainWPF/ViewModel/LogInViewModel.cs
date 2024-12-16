using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace RestaurantChainWPF.ViewModel
{
    public class LogInViewModel : INotifyPropertyChanged
    {
        private string _login;
        private string _password;
        private string _keyboardLayout;
        private string _capsLockStatus;

        private DispatcherTimer _timerForWindow = new();

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public string KeyboardLayout
        {
            get => _keyboardLayout;
            set
            {
                _keyboardLayout = value;
                OnPropertyChanged("KeyboardLayoutText");
            }
        }

        public string CapsLockStatus
        {
            get => _capsLockStatus;
            set
            {
                _capsLockStatus = value;
                OnPropertyChanged("CapsLockStatusText");
            }
        }

        public LogInViewModel()
        {
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
                CapsLockStatus = "Клавиша CapsLock нажата";
            else
                CapsLockStatus = "";

            KeyboardLayout = "Язык ввода " + ParseLanguage(InputLanguageManager.Current.CurrentInputLanguage.DisplayName);
        }

        private void StartTimer(long interval)
        {
            _timerForWindow.Interval = new TimeSpan(interval);
            // TODO: добавить смену версии из assembly
            _timerForWindow.Start();
            _timerForWindow.Tick += TimerTick;
        }
    }
}
