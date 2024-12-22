using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.RestaurantsViewModels;
using RestaurantChain.Presentation.ViewModel.SuppliersViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RestaurantChain.Presentation.View.RestaurantsViews
{
    /// <summary>
    /// Логика взаимодействия для RestaurantWindow.xaml
    /// </summary>
    public partial class RestaurantWindow : UserControl
    {
        /// <summary>
        /// Результат сохранения данных.
        /// </summary>
        public bool IsSuccess { private set; get; }

        public RestaurantWindow(IServiceProvider serviceProvider, int? restaurantId)
        {
            var restaurantsService = serviceProvider.GetRequiredService<IRestaurantsService>();
            var streetsService = serviceProvider.GetRequiredService<IStreetsService>();
            InitializeComponent();
            DataContext = new RestaurantViewModel(restaurantsService, streetsService, restaurantId);

            if (DataContext is SupplierViewModel supplierViewModel)
            {
                supplierViewModel.OnSaveSuccess += SaveSuccess;
                supplierViewModel.OnCancel += SaveError;
            }

            PreviewKeyDown += PreviewKeyDownHandle;
            Loaded += (sender, args) => { txtBox.Focus(); };
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

        private void PreviewKeyDownHandle(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    ((Window)Parent).Close();

                    break;
                case Key.Enter:
                    btnOk.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));

                    break;
            }
        }
    }
}
