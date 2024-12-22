using RestaurantChain.Presentation.ViewModel.RestaurantsViewModels;
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

namespace RestaurantChain.Presentation.View.RestaurantsViews
{
    /// <summary>
    /// Логика взаимодействия для RestaurantsListWindow.xaml
    /// </summary>
    public partial class RestaurantsListWindow : UserControl
    {
        public RestaurantsListWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            DataContext = new RestaurantListViewModel(serviceProvider);
        }
    }
}
