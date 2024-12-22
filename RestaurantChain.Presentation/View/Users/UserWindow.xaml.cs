using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.DomainServices.Contracts;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using RestaurantChain.Presentation.ViewModel.UsersViewModels.Users;

namespace RestaurantChain.Presentation.View.Users
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : UserControl
    {
        /// <summary>
        ///     Результат сохранения данных.
        /// </summary>
        public bool IsSuccess { private set; get; }

        public UserWindow(IServiceProvider serviceProvider, int? userId)
        {
            var usersService = serviceProvider.GetRequiredService<IUsersService>();
            InitializeComponent();
            DataContext = new UserViewModel(usersService, userId);

            if (DataContext is UserViewModel vm)
            {
                vm.OnSaveSuccess += SaveSuccess;
                vm.OnCancel += SaveError;
            }

            PreviewKeyDown += PreviewKeyDownHandle;
            //Loaded += (sender, args) => { txtBox.Focus(); };
        }

        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            ((Window) Parent).Close();
        }

        public void SaveSuccess()
        {
            IsSuccess = true;
            ((Window) Parent).Close();
        }

        public void SaveError()
        {
            IsSuccess = false;
            ((Window) Parent).Close();
        }

        private void PreviewKeyDownHandle(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    ((Window) Parent).Close();

                    break;
                case Key.Enter:
                    //btnOk.Command.Execute(null);

                    break;
            }
        }

        private void BtnOk_OnClick(object sender, RoutedEventArgs e)
        {
            (DataContext as UserViewModel).EnterCommand.Execute(sender);
        }
    }
}
