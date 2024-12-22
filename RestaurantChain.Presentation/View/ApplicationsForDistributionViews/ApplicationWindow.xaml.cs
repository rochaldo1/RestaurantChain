using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.ApplicationsForDistributionViewModel;
using RestaurantChain.Presentation.ViewModel.SuppliesViewModel;
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

namespace RestaurantChain.Presentation.View.ApplicationsForDistributionViews
{
    /// <summary>
    /// Логика взаимодействия для ApplicationWindow.xaml
    /// </summary>
    public partial class ApplicationWindow : UserControl
    {
        /// <summary>
        /// Результат сохранения данных.
        /// </summary>
        public bool IsSuccess { private set; get; }

        public ApplicationWindow(IServiceProvider serviceProvider, int? applicationId)
        {
            var applicationsForDistributionService = serviceProvider.GetRequiredService<IApplicationsForDistributionService>();
            var productsService = serviceProvider.GetRequiredService<IProductsService>();
            var restaurantsService = serviceProvider.GetRequiredService<IRestaurantsService>();

            InitializeComponent();
            DataContext = new ApplicationViewModel(applicationsForDistributionService, productsService, restaurantsService, applicationId);
            if (DataContext is ApplicationViewModel vm)
            {
                vm.OnSaveSuccess += SaveSuccess;
                vm.OnCancel += SaveError;
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
