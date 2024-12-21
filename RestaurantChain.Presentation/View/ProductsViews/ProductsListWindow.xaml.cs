using RestaurantChain.Presentation.ViewModel.ProductsViewModel;
using System.Windows.Controls;

namespace RestaurantChain.Presentation.View.ProductsViews
{
    /// <summary>
    /// Логика взаимодействия для ProductsListWindow.xaml
    /// </summary>
    public partial class ProductsListWindow : UserControl
    {
        public ProductsListWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            DataContext = new ProductListViewModel(serviceProvider);
        }
    }
}
