using RestaurantChain.Presentation.ViewModel.AvailibilityInRestaurantViewModel;
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

namespace RestaurantChain.Presentation.View.AvailibilityInRestaurantViews
{
    /// <summary>
    /// Логика взаимодействия для AvailibilityInRestaurantListWindow.xaml
    /// </summary>
    public partial class AvailibilityInRestaurantListWindow : UserControl
    {
        public AvailibilityInRestaurantListWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            DataContext = new AvailibilityListViewModel(serviceProvider);
        }
    }
}
