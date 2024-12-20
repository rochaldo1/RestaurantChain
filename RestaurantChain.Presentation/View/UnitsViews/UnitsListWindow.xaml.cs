using RestaurantChain.Presentation.ViewModel.UnitsViewModel;
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

namespace RestaurantChain.Presentation.View.UnitsViews
{
    /// <summary>
    /// Логика взаимодействия для UnitsListWindow.xaml
    /// </summary>
    public partial class UnitsListWindow : UserControl
    {
        public UnitsListWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            DataContext = new UnitListViewModel(serviceProvider);
        }
    }
}
