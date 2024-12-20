using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.SuppliersViewModel;
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

namespace RestaurantChain.Presentation.View.SuppliersViews
{
    /// <summary>
    /// Логика взаимодействия для SupplierWindow.xaml
    /// </summary>
    public partial class SupplierWindow : UserControl
    {
        /// <summary>
        /// Результат сохранения данных.
        /// </summary>
        public bool IsSuccess { private set; get; }

        public SupplierWindow(IServiceProvider serviceProvider, int? supplierId)
        {
            var suppliersService = serviceProvider.GetRequiredService<ISuppliersService>();
            var streetsService = serviceProvider.GetRequiredService<IStreetsService>();
            var banksService = serviceProvider.GetRequiredService<IBanksService>();
            InitializeComponent();
            DataContext = new SupplierViewModel(suppliersService, streetsService, banksService, supplierId);
            if (DataContext is SupplierViewModel supplierViewModel)
            {
                supplierViewModel.OnSaveSuccess += SaveSuccess;
                supplierViewModel.OnCancel += SaveError;
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
