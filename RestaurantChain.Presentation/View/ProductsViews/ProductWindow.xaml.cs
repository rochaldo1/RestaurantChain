using Microsoft.Extensions.DependencyInjection;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.ProductsViewModel;
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

namespace RestaurantChain.Presentation.View.ProductsViews
{
    /// <summary>
    /// Логика взаимодействия для ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : UserControl
    {
        /// <summary>
        /// Результат сохранения данных.
        /// </summary>
        public bool IsSuccess { private set; get; }

        public ProductWindow(IServiceProvider serviceProvider, int? productId)
        {
            var productsService = serviceProvider.GetRequiredService<IProductsService>();
            var unitsService = serviceProvider.GetService<IUnitsService>();
            InitializeComponent();
            DataContext = new ProductViewModel(productsService, unitsService, productId);
            if (DataContext is ProductViewModel productViewModel)
            {
                productViewModel.OnSaveSuccess += SaveSuccess;
                productViewModel.OnCancel += SaveError;
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
