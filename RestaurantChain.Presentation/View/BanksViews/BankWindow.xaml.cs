using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.BanksViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RestaurantChain.Presentation.View.BanksViews
{
    /// <summary>
    /// Логика взаимодействия для BankWindow.xaml
    /// </summary>
    public partial class BankWindow : UserControl
    {
        /// <summary>
        /// Результат сохранения данных.
        /// </summary>
        public bool IsSuccess { private set; get; }

        public BankWindow(IServiceProvider serviceProvider, int? bankId)
        {
            var banksService = serviceProvider.GetRequiredService<IBanksService>();
            InitializeComponent();
            DataContext = new BankViewModel(banksService, bankId);
            if (DataContext is BankViewModel bankViewModel)
            {
                bankViewModel.OnSaveSuccess += SaveSuccess;
                bankViewModel.OnCancel += SaveError;
            }
        }

        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            ((Window)Parent).Close();
        }

        public void SaveSuccess()
        {
            IsSuccess = true;
            ((Window)Parent).Close();
        }

        public void SaveError()
        {
            IsSuccess = false;
            ((Window)Parent).Close();
        }
    }
}
